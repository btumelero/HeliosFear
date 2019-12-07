using UnityEngine;

namespace Interfaces {

  namespace Missions {
    public interface INormalMission {

      GameObject player { get; set; }

      PlayerMovementController playerMovementController { get; }

      void preNormalMission ();

      void normalMission ();

      void postNormalMission ();

    }

  }
}
