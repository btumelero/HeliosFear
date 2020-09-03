using System.Collections;

using Assets.Source.App.Builders;
using Assets.Source.App.Builders.Spaceship;
using Assets.Source.App.Controllers.Respawn;
using Assets.Source.App.Controllers.Spaceship.Attack.Enemy;
using Assets.Source.App.Controllers.Spaceship.Life.Enemy.Boss;
using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Interfaces.Attacks;
using Assets.Source.App.Utils.Interfaces.Missions;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Mission.BossMission {

  /// <summary>
  /// Classe responsável por gerenciar missões de boss
  /// </summary>
  public abstract class BossMissionController : MissionController, IBossMission {

    #region Campos

    /// <summary>
    /// Responsável por controlar o respawn de inimigos
    /// </summary>
    [HideInInspector] public RespawnController respawnController;

    [HideInInspector] public CoroutineController missionEndCoroutine;

    /// <summary>
    /// Controlador de movimentos do boss
    /// </summary>
    protected ISpecialMovement bossMovement;

    /// <summary>
    /// Controlador de ataques do boss
    /// </summary>
    protected ISpecialAttack bossAttack;

    /// <summary>
    /// Controlador da vida do boss
    /// </summary>
    protected BossEnemyLifeController bossLife;

    /// <summary>
    /// A nave do boss
    /// </summary>
    public GameObject _boss;

    #endregion

    #region Propriedades

    /// <summary>
    /// A nave do boss
    /// </summary>
    public GameObject boss {
      get => _boss;
      set {
        _boss = value;
        onBossInstantiated();
      }
    }

    public float normalMissionTimer =>
      MissionData.values[MissionData.missionName].enemyData.normalMissionTimer
    ;

    #endregion

    #region Minhas Rotinas

    #region Estágio Pré-Boss

    /// <summary>
    /// Avança para o próximo estágio da missão quando o timer esgota
    /// </summary>
    public override IEnumerator onNormalMission () {
      missionEndCoroutine.play(onMission(onBossMissionEnd()));
      yield return new WaitForSeconds(normalMissionTimer);
      missionCoroutine.play(onNormalMissionEnd());
    }

    /// <summary>
    /// Começa a batalha contra o boss quando todos os inimigos estão mortos
    /// </summary>
    public override IEnumerator onNormalMissionEnd () {
      respawnController.respawnCoroutine.stop();
      yield return new WaitUntil(() => FindObjectsOfType<EnemyAttackController>().Length == 0);
      playerAttack.normalAttackCoroutine.stop();
      fixEdgesScale();
      boss = Instantiate(boss);
      missionCoroutine.play(onBossMissionStart());
    }


    #endregion

    #region Estágio Boss

    /// <summary>
    /// Move o jogador para a posição inicial e, assim que ele e o boss estiverem em posição, 
    /// começa a batalha avançando a missão para o próximo estágio
    /// </summary>
    public IEnumerator onBossMissionStart () {
      playerMovement.movementCoroutine.stop();
      while (
        playerMovement.positionIs(playerMovement.startingPosition) == false ||
        bossMovement.positionIs(bossMovement.startingPosition) == false
      ) {
        yield return new WaitForFixedUpdate();
        playerMovement.moveTowards(
          playerMovement.startingPosition,
          playerMovement.actualSpeed
        );
      }
      playerAttack.normalAttackCoroutine.play(playerAttack.normalAttack());
      playerMovement.movementCoroutine.play(playerMovement.normalMovement());
      missionCoroutine.play(onBossMission());
    }

    /// <summary>
    /// Acaba o jogo quando o boss ou o jogador morrerem
    /// </summary>
    public virtual IEnumerator onBossMission () {//-------------------------------------------
      while (true) {
        yield return new WaitForFixedUpdate();
        if (gameOver() == false) {
          updateBoss();
          updateOthers();
          updatePlayer();
        }
      }
    }

    /// <summary>
    /// Volta para o menu principal quando o jogo acabar
    /// </summary>
    public virtual IEnumerator onBossMissionEnd () {
      yield return new WaitUntil(() => true);//-----------------------------------------------
      Game.loadScene(Scenes.Menu);
    }

    #endregion

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Afasta as bordas para o boss não bater nelas
    /// </summary>
    private void fixEdgesScale () {
      Game.findWithTag(Tags.Edges).transform.localScale = new Vector3(2, 2, 2);
    }

    /// <summary>
    /// Modifica o tamanho da tela
    /// </summary>
    protected void fixPlayerScreenView () {
      GameObject blackSides = Game.findWithTag(Tags.BlackSides);
      blackSides.transform.localScale = new Vector3(
        x: blackSides.transform.localScale.x == 1 ? 1.23f : 1,
        y: 1,
        z: 1
      );
    }

    /// <summary>
    /// Subclasses devem implementar mudanças no comportamento do boss durante o estágio boss da missão
    /// </summary>
    public abstract void updateBoss ();

    /// <summary>
    /// Subclasses devem implementar mudanças no comportamento do player durante o estágio boss da missão
    /// </summary>
    public abstract void updatePlayer ();

    /// <summary>
    /// Subclasses devem implementar mudanças no comportamento de outras coisas durante o estágio boss da missão
    /// </summary>
    public abstract void updateOthers ();

    protected virtual void onBossInstantiated () {
      new Builder().set(new BossBuilder()).build(boss);
      bossMovement = boss.GetComponent<ISpecialMovement>();
      bossAttack = boss.GetComponent<ISpecialAttack>();
      bossLife = boss.GetComponent<BossEnemyLifeController>();
    }

    /// <summary>
    /// Retorna verdadeiro quando o boss ou o jogador estiverem mortos
    /// </summary>
    /// 
    /// <returns>
    /// Verdadeiro se o jogo acabou
    /// </returns>
    protected override bool gameOver () {
      return boss == null || base.gameOver();
    }

    #endregion

  }
}
