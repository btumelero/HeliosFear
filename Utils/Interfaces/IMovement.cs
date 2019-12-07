using UnityEngine;

namespace Interfaces {

  namespace Movements {

    public interface IMovement : IMove {

      Vector3 startingPosition { get; }

      GameObject spaceship { get; }

      void normalMovement ();

    }

  }
}
