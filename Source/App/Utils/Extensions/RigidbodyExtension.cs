using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Assets.Source.App.Utils.Extensions {

  /// <summary>
  /// Extensões da classe RigidBody
  /// </summary>
  public static class RigidbodyExtension {

    /// <summary>
    /// Faz o objeto se mover na velocidade e direção passadas por parâmetro
    /// </summary>
    /// 
    /// <param name="rigidBody">
    /// O corpo desse objeto
    /// </param>
    /// 
    /// <param name="direction">
    /// A direção de movimento
    /// </param>
    /// 
    /// <param name="velocity">
    /// A velocidade de movimentação
    /// </param>
    public static void setVelocity (this Rigidbody rigidBody, Vector3 direction, float velocity) {
      rigidBody.velocity = direction * velocity;
    }

  }

}
