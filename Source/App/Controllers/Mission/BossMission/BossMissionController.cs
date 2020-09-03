using Extensions;

using Interfaces.Missions;

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsável por gerenciar missões de boss
/// </summary>
public abstract class BossMissionController : MissionController, IBossMission {

  #region Variáveis

  /// <summary>
  /// Responsável por controlar o respawn de inimigos
  /// </summary>
  public RespawnController respawnController { get; set; }

  /// <summary>
  /// Timer que controla a duração da missão
  /// </summary>
  public Timer normalMissionTimer { get; set; }

  /// <summary>
  /// Controlador de movimentos do boss
  /// </summary>
  protected BossEnemyMovementController _bossEnemyMovementController;

  /// <summary>
  /// Controlador de ataques do boss
  /// </summary>
  protected BossEnemyAttackController _bossEnemyAttackController;

  /// <summary>
  /// A nave do boss
  /// </summary>
  public GameObject _boss;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// A nave do boss
  /// </summary>
  public GameObject boss {
    get => _boss;
    set {
      _boss = value;
      _bossEnemyMovementController = _boss.GetComponent<BossEnemyMovementController>();
      _bossEnemyAttackController = _boss.GetComponent<BossEnemyAttackController>();
    }
  }

  /// <summary>
  /// Controlador de movimentos do boss
  /// </summary>
  public BossEnemyMovementController bossMovementController { 
    get => _bossEnemyMovementController; 
  }

  /// <summary>
  /// Controlador de ataques do boss
  /// </summary>
  public BossEnemyAttackController bossAttackController {
    get => _bossEnemyAttackController;
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Avança para o próximo estágio da missão quando o timer esgota
  /// </summary>
  public override void normalMission () {
    base.normalMission();
    if (normalMissionTimer.timeIsUp()) {
      missionStage = postNormalMission;
    }
  }

  /// <summary>
  /// Começa a batalha contra o boss quando todos os inimigos estão mortos
  /// </summary>
  public override void postNormalMission () {
    respawnController.respawn = null;
    if (GameObject.FindGameObjectsWithTag(Enums.Tags.Enemy.ToString()).Length == 0) {
      Destroy(normalMissionTimer);
      fixEdgesScale();
      boss = Instantiate(_boss);
      playerAttackController.attack = null;
      missionStage = preBossMission;
    }
  }

  /// <summary>
  /// Afasta as bordas para o boss não bater nelas
  /// </summary>
  private void fixEdgesScale () {
    GameObject.FindWithTag(Enums.Tags.Edges.ToString()).transform.localScale = new Vector3(2, 2, 2);
  }

  /// <summary>
  /// Modifica o tamanho da tela
  /// </summary>
  protected void fixPlayerScreenView () {
    GameObject blackSides = GameObject.FindWithTag(Enums.Tags.BlackSides.ToString());
    blackSides.transform.localScale = new Vector3(
      blackSides.transform.localScale.x == 1 ? 1.23f : 1,
      1,
      1
    );
  }

  /// <summary>
  /// Move o jogador para a posição inicial e, assim que ele e o boss estiverem em posição, 
  /// começa a batalha avançando a missão para o próximo estágio
  /// </summary>
  public virtual void preBossMission () {
    if (player.isAt(playerMovementController._startingPosition) == false) {
      playerMovementController.move = null;
      player.moveTowards(playerMovementController._startingPosition, playerMovementController._actualSpeed);
    } else {
      if (_boss.isAt(_bossEnemyMovementController.startingPosition)) {
        playerAttackController.attack = playerAttackController.normalAttack;
        playerMovementController.move = playerMovementController.normalMovement;
        missionStage = bossMission;
      }
    }
  }

  /// <summary>
  /// Acaba o jogo quando o boss ou o jogador morrerem
  /// </summary>
  public virtual void bossMission () {
    if (gameOver()) {
      missionStage = postBossMission;
    }
    updateBoss();
    updateOthers();
    updatePlayer();
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


  /// <summary>
  /// Volta para o menu principal quando o jogo acabar
  /// </summary>
  public virtual void postBossMission () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }

  /// <summary>
  /// Retorna verdadeiro quando o boss ou o jogador estiverem mortos
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o jogo acabou
  /// </returns>
  public override bool gameOver () {
    return boss == null || base.gameOver();
  }

  #endregion

}
