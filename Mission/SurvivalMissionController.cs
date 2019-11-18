public class SurvivalMissionController : MissionController {

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   * Inicializa o tempo que vai levar pra um novo inimigo aparecer e chance pra cada tipo
   */
  protected override void Start () {
    base.Start();
    timer.baseTime = 1.125f;
    spawnChance[(byte) enemyType.ATTACKER] = 15;
    spawnChance[(byte) enemyType.DEFENDER] = 15;
    spawnChance[(byte) enemyType.DODGER] = 30;
    spawnChance[(byte) enemyType.NORMAL] = 40;
  }

  #endregion

}
