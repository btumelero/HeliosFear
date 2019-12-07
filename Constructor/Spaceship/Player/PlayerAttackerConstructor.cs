﻿public class PlayerAttackerConstructor : PlayerConstructor {
  
  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.15f;
    attackController.baseShootPower = 2.5f;
  }

  protected override void setUpLife () {
    lifeController._hp = 6;
    lifeController.baseShield = 12;
    lifeController.baseRegenerationSpeed = 0.75f;
    base.setUpLife();
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.baseSpeed *= 25;
    movementController.screenLimits.minimumX = -26;
    movementController.screenLimits.maximumX = 26;
    movementController.screenLimits.minimumY = -34;
    movementController.screenLimits.maximumY = 36;
  }

  #endregion

}