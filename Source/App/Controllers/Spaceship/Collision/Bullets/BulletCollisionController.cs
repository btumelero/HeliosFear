using Assets.Source.App.Controllers.Bullets;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Collision.Bullets {

  /// <summary>
  /// Classe responsável pelo comportamento de colisões com tiros
  /// </summary>
  public class BulletCollisionController : CollisionController {

    #region Variáveis

    /// <summary>
    /// O controlador do tiro
    /// </summary>
    protected BulletController bulletController { get; set; }

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Inicialização apenas
    /// </summary>
    protected virtual void Start () {
      bulletController = gameObject.GetComponentInParent<BulletController>();
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Dá dano ao colidir com um alvo
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    protected override void onCollision (Collider collider) {
      if (colliderLifeController != null) {
        bulletController.hit(colliderLifeController);
      }
    }

    #endregion

  }
}
