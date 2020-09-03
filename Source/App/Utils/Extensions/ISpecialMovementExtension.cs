using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Assets.Source.App.Utils.Extensions {

  /// <summary>
  /// Extensões da interface ISpecialMovement
  /// </summary>
  public static class ISpecialMovementExtension {

    /// <summary>
    /// Retorna verdadeiro se a rotação desse objeto é àquela passada por parâmetro
    /// </summary>
    /// 
    /// <param name="specialMovement">
    /// O objeto que terá a rotação checada (esse objeto)
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser usada na comparação
    /// </param>
    /// 
    /// <returns>
    /// verdadeiro se as rotações são iguaia
    /// </returns>
    public static bool rotationIs (this ISpecialMovement specialMovement, Quaternion rotation) {
      return specialMovement.gameObject.transform.root.rotation.eulerAngles.Equals(rotation.eulerAngles);
    }

    /// <summary>
    /// Rotaciona o objeto para rotação passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="specialMovement">
    /// O objeto que seá rotacionado (esse objeto)
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de rotação
    /// </param>
    public static void rotateTowards (this ISpecialMovement specialMovement, Quaternion rotation, float speed) {
      specialMovement.gameObject.transform.root.rotation = Quaternion.RotateTowards(
        specialMovement.gameObject.transform.root.rotation,
        rotation,
        speed * Time.fixedDeltaTime
      );
    }

    /// <summary>
    /// Retorna verdadeiro se a posição e a rotação do objeto forem iguais às passadas por parâmetro.
    /// </summary>
    /// 
    /// <param name="specialMovement">
    /// O objeto que terá a posição e rotação checadas.
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser checada.
    /// </param>
    /// 
    /// <param name="rotation">
    /// A rotação a ser checada.
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se a posição e a rotação do objeto forem iguais às passadas por parâmetro.
    /// </returns>
    public static bool positionAndRotationEquals (this ISpecialMovement specialMovement, Vector3 position, Quaternion rotation) {
      return specialMovement.positionIs(position) && specialMovement.rotationIs(rotation);
    }

  }
}