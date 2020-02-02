using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da classe GameObject
  /// </summary>
  public static class GameObjectExtension {

    /// <summary>
    /// Retorna verdadeiro esse objeto está na posição passada por parâmetro
    /// </summary>
    /// 
    /// <param name="gameObject">
    /// O objeto que terá a posição checada (esse objeto)
    /// </param>
    /// 
    /// <param name="position">
    /// A posição que será checada
    /// </param>
    /// 
    /// <returns>
    /// verdadeiro esse objeto está na posição
    /// </returns>
    public static bool isAt (this GameObject gameObject, Vector3 position) {
      if (gameObject != null) {
        return gameObject.transform.root.position.isAt(position);
      }
      return false;
    }

    /// <summary>
    /// Move o objeto para a posição passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="gameObject">
    /// O objeto que será movido (esse objeto)
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de movimentação
    /// </param>
    public static void moveTowards (this GameObject gameObject, Vector3 position, float speed) {
      gameObject.transform.root.position = gameObject.transform.root.position.moveTowards(
        position,
        speed
      );
    }

    /// <summary>
    /// Retorna verdadeiro se a rotação do objeto é igual a zero
    /// </summary>
    /// 
    /// <param name="gameObject">
    /// O objeto que terá a rotação checada (esse objeto)
    /// </param>
    /// 
    /// <returns>
    /// verdadeiro se a rotação é igual a zero
    /// </returns>
    public static bool rotationIsZero (this GameObject gameObject) {
      return gameObject.transform.root.rotation.isZero();
    }

    /// <summary>
    /// Rotaciona o objeto para rotação passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="gameObject">
    /// O objeto que será rotacionado (esse objeto)
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de rotação
    /// </param>
    public static void rotateTowards (this GameObject gameObject, Quaternion rotation, float speed) {
      gameObject.transform.root.rotation = gameObject.transform.root.rotation.rotateTowards(
        rotation,
        speed
      );
    }

  }

}
