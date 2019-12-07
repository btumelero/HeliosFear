using UnityEngine;

public abstract class BossEnemyConstructor : EnemyConstructor {

  #region Getters e Setters

  public new BossEnemyMovementController movementController {
    get => (BossEnemyMovementController) _movementController;
  }

  public new BossEnemyAttackController attackController {
    get => (BossEnemyAttackController) _attackController;
  }

  #endregion

  #region Meus Métodos

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.totalEnergy = 300;
  }

  protected override void setUpMovement () {
    movementController._spaceship = gameObject;
    movementController.move = movementController.normalMovement;
  }

  #endregion

}
