using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Assets.Source.App.Utils.Extensions {

  /// <summary>
  /// Extensões da interface IMovement
  /// </summary>
  public static class IMovementExtension {

    /// <summary>
    /// Move gradualmente o objeto para a posição passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="movement">
    /// O objeto que irá se mover
    /// </param>
    /// 
    /// <param name="targetPosition">
    /// A posição a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de movimentação
    /// </param>
    public static void moveTowards (this IMovement movement, Vector3 targetPosition, float speed) {
      movement.gameObject.transform.root.position = Vector3.MoveTowards(
        movement.gameObject.transform.root.position,
        targetPosition,
        speed * Time.fixedDeltaTime
      );
    }

    /// <summary>
    /// Retorna verdadeiro esse objeto está na posição passada por parâmetro
    /// </summary>
    /// 
    /// <param name="vector3">
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
    public static bool positionIs (this IMovement movement, Vector3 position) {
      return Vector3.Distance(movement.gameObject.transform.root.position, position) == 0;
    }

  }
}
