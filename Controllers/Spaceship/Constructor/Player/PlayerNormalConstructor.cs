public class PlayerNormalConstructor : PlayerConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.2f;
    attackController.baseShootPower = 2;
  }

  protected override void setUpLife () {
    lifeController._hp = 8;
    lifeController.baseShield = 16;
    lifeController.baseRegenerationSpeed = 1;
    base.setUpLife();
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.baseSpeed = 30;
    movementController.screenLimits.minimumX = -28;
    movementController.screenLimits.maximumX = 28;
    movementController.screenLimits.minimumY = -35;
    movementController.screenLimits.maximumY = 37;
  }

  #endregion

}
