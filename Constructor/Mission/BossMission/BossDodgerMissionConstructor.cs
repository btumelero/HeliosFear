using UnityEngine;

public class BossDodgerMissionConstructor : BossMissionConstructor {

  public new BossDodgerMissionController missionController {
    get => (BossDodgerMissionController) _missionController;
  }

  protected override void setUpMissionController () {
    base.setUpMissionController();
    missionController.spaceship = GetComponentInChildren<Renderer>();
    //normalMissionTimer.baseTime = 1;
  }

  protected override void setUpRespawnController () {
    base.setUpRespawnController();
    _respawnController.spawnChance[(byte) Enums.Spaceships.Attacker] = 10;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Defender] = 10;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Dodger] = 50;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Normal] = 30;
    _respawnController.respawnTimer.baseTime = 1.25f;
  }

}
