using UnityEngine;

namespace Interfaces {

  namespace Missions {

    public interface IBossMission {

      GameObject boss { get; }

      BossEnemyMovementController bossMovementController { get; }

      void postNormalMission ();

      void bossMission ();

      void postBossMission ();

    }

  }
}
