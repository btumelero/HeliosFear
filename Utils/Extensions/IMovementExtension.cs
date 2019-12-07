using Extensions;

using Interfaces.Movements;

public static class IMovementExtension {
  
  public static void moveTowardsStartingPosition (this IMovement movement) {
    movement.spaceship.moveTowards(movement.startingPosition, movement.actualSpeed);
  }

}
