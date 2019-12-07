using UnityEngine;

namespace Interfaces {

  namespace Movements {

    public interface ISpecialMovement : IMovement {

      Vector3 specialPosition { get; }

      void specialMovement ();

      void switchToSpecialMovement ();

      void switchToNormalMovement ();

    }

  }

}
