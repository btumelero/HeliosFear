public class BossAttackerMissionConstructor : BossMissionConstructor {

  protected override void setUpMissionController () {
    base.setUpMissionController();
    //facingEnemiesTimer.baseTime = 600;
  }

  protected override void setUpRespawnController () {
    base.setUpRespawnController();
    _respawnController.respawnTimer.baseTime = 1.25f;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Attacker] = 30;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Defender] = 10;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Dodger] = 25;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Normal] = 35;
  }

}
