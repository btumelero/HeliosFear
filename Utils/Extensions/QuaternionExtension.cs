using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da classe Quaternion
  /// </summary>
  public static class QuaternionExtension {

    /// <summary>
    /// Retorna verdadeiro se a rotação do objeto é igual a zero
    /// </summary>
    /// 
    /// <param name="quaternion">
    /// A rotação desse objeto
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se a rotação é zero
    /// </returns>
    public static bool isZero (this Quaternion quaternion) {
      return quaternion.Equals(Quaternion.Euler(0, 0, 0));
    }

    /// <summary>
    /// Rotaciona o objeto para rotação passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="quaternion">
    /// A rotação desse objeto
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de rotação
    /// </param>
    /// 
    /// <returns>
    /// Um quaternion com a rotação atual
    /// </returns>
    public static Quaternion rotateTowards (this Quaternion quaternion, Quaternion rotation, float speed) {
      return Quaternion.RotateTowards(
        quaternion,
        rotation,
        speed * Time.fixedDeltaTime
      );
    }

  }

}
