﻿public class BossAttackerMissionController : BossMissionController {

  protected override void Start () {
    base.Start();
    timer.baseTime = 1.25f;
    spawnChance[(byte) Enums.Spaceships.Attacker] = 30;
    spawnChance[(byte) Enums.Spaceships.Defender] = 10;
    spawnChance[(byte) Enums.Spaceships.Dodger] = 25;
    spawnChance[(byte) Enums.Spaceships.Normal] = 35;
  }

}
