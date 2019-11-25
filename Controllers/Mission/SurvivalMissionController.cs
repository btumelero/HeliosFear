public class SurvivalMissionController : MissionController {

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   * Inicializa o tempo que vai levar pra um novo inimigo aparecer e chance pra cada tipo
   */
  protected override void Start () {
    base.Start();
    timer.baseTime = 1.125f;
    spawnChance[(byte) Enums.Spaceships.Attacker] = 15;
    spawnChance[(byte) Enums.Spaceships.Defender] = 15;
    spawnChance[(byte) Enums.Spaceships.Dodger] = 30;
    spawnChance[(byte) Enums.Spaceships.Normal] = 40;
  }

  #endregion

}
