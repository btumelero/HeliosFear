using Extensions;

using Interfaces.Movements;

public static class ISpecialMovementExtension {

  public static void moveTowardsSpecialPosition (this ISpecialMovement movement) {
    movement.spaceship.moveTowards(movement.specialPosition, movement.actualSpeed);
  }

}
