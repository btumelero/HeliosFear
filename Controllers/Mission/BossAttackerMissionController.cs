public class BossAttackerMissionController : BossMissionController {

  protected override void Start () {
    base.Start();
    timer.baseTime = 1.25f;
    spawnChance[(byte) enemyType.ATTACKER] = 30;
    spawnChance[(byte) enemyType.DEFENDER] = 10;
    spawnChance[(byte) enemyType.DODGER] = 25;
    spawnChance[(byte) enemyType.NORMAL] = 35;
  }

}

