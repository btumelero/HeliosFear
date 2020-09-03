using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Collision
{
  /// <summary>
  /// Classe responsável pela colisão com alguma parte de outra nave
  /// </summary>
  public class SpaceshipCollisionController : CollisionController {

    #region Métodos da Unity

    /// <summary>
    /// Continua dando dano enquanto as naves/escudos continuarem colidindo
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    private void OnTriggerStay (Collider collider) {
      onCollision(collider);
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Diminui vida/escudo da nave se houver uma colisão com outra nave/escudo
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    protected override void onCollision (Collider collider) {
      if (colliderLifeController != null) {
        colliderLifeController.shield.Value -= Time.deltaTime * 10;
      }
    }

    #endregion

  }
}
