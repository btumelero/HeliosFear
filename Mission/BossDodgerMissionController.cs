public class BossDodgerMissionController : BossMissionController {

  protected override void Start () {
    base.Start();
    timer.baseTime = 1.25f;
    spawnChance[(byte) enemyType.ATTACKER] = 10;
    spawnChance[(byte) enemyType.DEFENDER] = 10;
    spawnChance[(byte) enemyType.DODGER] = 50;
    spawnChance[(byte) enemyType.NORMAL] = 30;
  }

}
