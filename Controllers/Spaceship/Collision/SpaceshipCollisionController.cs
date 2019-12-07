using UnityEngine;

public abstract class SpaceshipCollisionController : CollisionController {

  /**
   * Diminui a/o vida/escudo da nave sempre que houver uma colisão
   */
  protected override void onCollision () {
    if (colliderLifeController != null) {
      colliderLifeController.shield--;
    }
  }

}
