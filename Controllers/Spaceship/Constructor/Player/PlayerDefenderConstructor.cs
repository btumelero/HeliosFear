public class PlayerDefenderConstructor : PlayerConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.3f;
    attackController.baseShootPower = 1f;
  }

  protected override void setUpLife () {
    lifeController._hp = 12;//_
    lifeController.baseShield = 24;
    lifeController.baseRegenerationSpeed = 2;
    base.setUpLife();
  }

  protected override void setUpMovement () {
    movementController.baseSpeed = 20;
    movementController.screenLimits.minimumX = -26;
    movementController.screenLimits.maximumX = 26;
    movementController.screenLimits.minimumY = -34;
    movementController.screenLimits.maximumY = 36;
  }

  #endregion

}
