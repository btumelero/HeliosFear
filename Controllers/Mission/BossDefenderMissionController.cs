using UnityEngine;

public class BossDefenderMissionController : BossMissionController {

  #region

  private PlayerMovementController playerMovementController;

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    playerMovementController = GameObject.FindWithTag(Enums.Tags.Player.ToString());
    timer.baseTime = 1.25f;
    spawnChance[(byte) Enums.Spaceships.Attacker] = 10;
    spawnChance[(byte) Enums.Spaceships.Defender] = 30;
    spawnChance[(byte) Enums.Spaceships.Dodger] = 25;
    spawnChance[(byte) Enums.Spaceships.Normal] = 35;
  }

  #endregion

  #region Meus Métodos

  private void switchMovementType () {
    playerMovementController.move = playerMovementController.toScreenCenter;
    if (playerMovementController.transform.position == Vector3.zero) {
      playerMovementController.move = playerMovementController.specialMovement;
    }
  }

  #endregion

}
