using Extensions;

using Interfaces.Missions;

using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BossMissionController : MissionController, IBossMission {

  #region Variáveis

  public RespawnController respawnController { get; set; }
  public Timer normalMissionTimer { get; set; }
  protected BossEnemyMovementController _bossEnemyMovementController;
  public GameObject _boss;


  #endregion

  #region Getters e Setters

  public GameObject boss {
    get => _boss;
    set {
      _boss = value;
      _bossEnemyMovementController = _boss.GetComponent<BossEnemyMovementController>();
    }
  }

  public BossEnemyMovementController bossMovementController { 
    get => _bossEnemyMovementController; 
  }

  #endregion

  #region Meus Métodos

  public override void normalMission () {
    base.normalMission();
    if (normalMissionTimer.timeIsUp()) {
      missionStage = postNormalMission;
    }
  }

  /**
   * Starts boss battle after all enemies are dead
   */
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

  private void fixEdgesScale () {
    GameObject.FindWithTag(Enums.Tags.Edges.ToString()).transform.localScale = new Vector3(2, 2, 2);
  }

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

  public virtual void bossMission () {
    if (gameOver()) {
      missionStage = postBossMission;
    }
  }

  public virtual void postBossMission () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }

  public override bool gameOver () {
    return boss == null || base.gameOver();
  }

  #endregion

}
