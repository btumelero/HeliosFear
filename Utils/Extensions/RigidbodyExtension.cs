using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da classe RigidBody
  /// </summary>
  public static class RigidbodyExtension {

    /// <summary>
    /// Retorna verdadeiro esse objeto está na posição passada por parâmetro
    /// </summary>
    /// 
    /// <param name="rigidbody">
    /// O corpo desse objeto
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser checada
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se está na posição indicada
    /// </returns>
    public static bool isAt (this Rigidbody rigidbody, Vector3 position) {
      return rigidbody.transform.root.position.isAt(position);
    }

    /// <summary>
    /// Move o objeto para a posição passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="rigidbody">
    /// O corpo desse objeto
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de movimentação
    /// </param>
    public static void moveTowards (this Rigidbody rigidbody, Vector3 position, float speed) {
      rigidbody.transform.root.position = rigidbody.transform.root.position.moveTowards(
        position,
        speed
      );
    }

    /// <summary>
    /// Retorna verdadeiro se a rotação do objeto é igual a zero
    /// </summary>
    /// 
    /// <param name="rigidbody">
    /// O corpo desse objeto
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se a rotação é zero
    /// </returns>
    public static bool rotationIsZero (this Rigidbody rigidbody) {
      return rigidbody.transform.root.rotation.isZero();
    }

    /// <summary>
    /// Rotaciona o objeto para rotação passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="rigidbody">
    /// O corpo desse objeto
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de rotação
    /// </param>
    public static void rotateTowards (this Rigidbody rigidbody, Quaternion rotation, float speed) {
      rigidbody.transform.root.rotation = rigidbody.transform.root.rotation.rotateTowards(
        rotation,
        speed
      );
    }

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

    /// <summary>
    /// Rotaciona o objeto na direção em que está se movendo
    /// </summary>
    /// 
    /// <param name="rigidBody">
    /// O corpo desse objeto
    /// </param>
    public static void fixRotation (this Rigidbody rigidBody) {
      rigidBody.transform.root.LookAt(rigidBody.velocity + rigidBody.transform.position);
    }
  }

}
