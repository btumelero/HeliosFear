/// <summary>
/// Classe responsável pela colisão com alguma parte de outra nave
/// </summary>
public abstract class SpaceshipCollisionController : CollisionController {

  /// <summary>
  /// Diminui vida/escudo da nave sempre que houver uma colisão válida
  /// </summary>
  protected override void onCollision () {
    if (colliderLifeController != null) {
      colliderLifeController.shield--;
    }
  }

}
