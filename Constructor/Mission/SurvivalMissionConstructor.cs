/// <summary>
/// Classe responsável por inicializar a missão de sobrevivência.
/// </summary>
public class SurvivalMissionConstructor : MissionConstructor {

  #region Meus Métodos

  protected override void setUpRespawnController () {
    base.setUpRespawnController();
    _respawnController.respawnTimer.baseTime = 1.125f;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Attacker] = 15;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Defender] = 15;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Dodger] = 30;
    _respawnController.spawnChance[(byte) Enums.Spaceships.Normal] = 40;
  }

  #endregion

}
