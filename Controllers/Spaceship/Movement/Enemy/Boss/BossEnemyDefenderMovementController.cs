using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class BossEnemyDefenderMovementController : BossEnemyMovementController {

  #region Variáveis

  public Vector3 offscreenPosition, specialPosition;
  public Timer bossMovementTimer { get; set; }
  public List<Vector3> movementList { get; set; }

  #endregion

  #region Meus métodos

  private void moveTowardsDestination () {
    spaceship.moveTowards(movementList[0], _actualSpeed);
    if (spaceship.isAt(movementList[0])) {
      movementList.RemoveAt(0);
    }
    if (movementList.Count == 0) {
      bossMovementTimer.restart();
      move = normalMovement;
    }
  }

  public override void normalMovement () {
    if (bossMovementTimer.timeIsUp()) {
      movementList.Add(offscreenPosition);
      if (spaceship.isAt(startingPosition)) {
        movementList.Add(specialPosition);
      } else if (spaceship.isAt(specialPosition)) {
        movementList.Add(startingPosition);
      }
      move = moveTowardsDestination;
    }
  }

  #endregion

}
