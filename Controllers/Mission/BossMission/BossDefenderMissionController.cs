using Extensions;
using UnityEngine;

public class BossDefenderMissionController : BossMissionController {

  #region Variáveis

  public RespawnZone respawnZone { get; set; }

  #endregion

  #region Getters e Setters

  public new BossEnemyDefenderMovementController bossMovementController {
    get => (BossEnemyDefenderMovementController) _bossEnemyMovementController;
  }

  public new PlayerSpecialMovementController playerMovementController {
    get => (PlayerSpecialMovementController) _playerMovementController;
  }

  #endregion

  #region Meus Métodos

  public override void preBossMission () {
    base.preBossMission();
    respawnController.respawnTimer.baseTime = 0.3f;
  }

  public override void bossMission () {
    base.bossMission();
    if (boss.isAt(bossMovementController.specialPosition)) {
      if (respawnController.respawn == null) {
        respawnController.respawn = respawnController.specialRespawn;
      }
      if (playerMovementController.move == playerMovementController.normalMovement) {
        playerMovementController.move = playerMovementController.switchToSpecialMovement;
      }
    } else {
      if (respawnController.respawn == respawnController.specialRespawn) {
        respawnController.respawn = null;
      }
      if (playerMovementController.move == playerMovementController.specialMovement) {
        if (GameObject.FindGameObjectsWithTag(Enums.Tags.Enemy.ToString()).Length == 0) {
          playerMovementController.move = playerMovementController.switchToNormalMovement;
        }
      }
    }
  }

  #endregion

}
