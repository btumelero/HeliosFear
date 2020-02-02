using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da classe Transform
  /// </summary>
  public static class TransformExtension {

    /// <summary>
    /// Retorna verdadeiro esse objeto está na posição passada por parâmetro
    /// </summary>
    /// 
    /// <param name="transform">
    /// A posição desse objeto
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser checada
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se está na posição
    /// </returns>
    public static bool isAt (this Transform transform, Vector3 position) {
      return transform.root.position.isAt(position);
    }

    /// <summary>
    /// Move o objeto para a posição passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="transform">
    /// A posição desse objeto
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de movimentação
    /// </param>
    public static void moveTowards (this Transform transform, Vector3 position, float speed) {
      transform.root.position = transform.root.position.moveTowards(
        position,
        speed
      );
    }

    /// <summary>
    /// Rotaciona o objeto para rotação passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="transform">
    /// A posição desse objeto
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de rotação
    /// </param>
    public static void rotateTowards (this Transform transform, Quaternion rotation, float speed) {
      transform.root.rotation = transform.root.rotation.rotateTowards(
        rotation,
        speed
      );
    }

  }

}
