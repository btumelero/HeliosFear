public class PlayerDodgerConstructor : PlayerConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.25f;
    attackController.baseShootPower = 1.5f;
  }

  protected override void setUpLife () {
    lifeController._hp = 4;//_
    lifeController.baseShield = 8;
    lifeController.baseRegenerationSpeed = 0.5f;
    base.setUpLife();
  }

  protected override void setUpMovement () {
    movementController.baseSpeed = 40;
    movementController.screenLimits.minimumX = -28;
    movementController.screenLimits.maximumX = 28;
    movementController.screenLimits.minimumY = -36;
    movementController.screenLimits.maximumY = 38;
  }

  #endregion

}
