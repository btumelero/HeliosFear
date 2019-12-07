public class BossDefenderMissionConstructor : BossMissionConstructor {

  #region Getters e Setters

  public new BossDefenderMissionController missionController {
    get => (BossDefenderMissionController) _missionController;
  }

  #endregion

  #region Meus Métodos

  protected override void setUpMissionController () {
    base.setUpMissionController();
    //missionController.normalMissionTimer.baseTime = 1;
  }

  protected override void setUpRespawnController () {
    base.setUpRespawnController();
    _respawnController.spawnChance[(byte) Enums.Spaceships.Attacker] = 10;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Defender] = 30;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Dodger] = 25;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Normal] = 35;
    _respawnController.respawnTimer.baseTime = 1.25f;
  }

  protected override void setUpRespawnZone () {
    base.setUpRespawnZone();
    missionController.respawnZone = respawnZone;
  }

  #endregion

}
