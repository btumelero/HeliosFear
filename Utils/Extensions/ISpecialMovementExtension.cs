using Interfaces.Movements;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da interface ISpecialMovement
  /// </summary>
  public static class ISpecialMovementExtension {

    /// <summary>
    /// Move o objeto para sua posição especial
    /// </summary>
    /// 
    /// <param name="movement">
    /// O objeto que irá se mover (esse objeto)
    /// </param>
    public static void moveTowardsSpecialPosition (this ISpecialMovement movement) {
      movement.spaceship.moveTowards(movement.specialPosition, movement.actualSpeed);
    }

  }

}
