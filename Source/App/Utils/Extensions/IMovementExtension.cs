using Interfaces.Movements;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da interface IMovement
  /// </summary>
  public static class IMovementExtension {

    /// <summary>
    /// Move o objeto para sua posição inicial
    /// </summary>
    /// 
    /// <param name="movement">
    /// O objeto que irá se mover (esse objeto)
    /// </param>
    public static void moveTowardsStartingPosition (this IMovement movement) {
      movement.spaceship.moveTowards(movement.startingPosition, movement.actualSpeed);
    }

  }

}
