using Assets.Source.App.Controllers.Spaceship.Life;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Collision {

  /// <summary>
  /// Controla o comportamento de colisões
  /// </summary>
  public abstract class CollisionController : MonoBehaviour {

    #region Variáveis

    /// <summary>
    /// O controlador de vida do objeto que colidiu com esse objeto
    /// </summary>
    protected LifeController colliderLifeController;

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Esse método gerencia as colisões do objeto tiver esse Script.
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    protected virtual void OnTriggerEnter (Collider collider) {
      colliderLifeController = collider.transform.root.GetComponent<LifeController>();
      onCollision(collider);
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Deve dar dano sempre que houver uma colisão
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    protected abstract void onCollision (Collider collider);

    #endregion

  }
}
