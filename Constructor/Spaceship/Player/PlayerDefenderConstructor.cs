﻿/// <summary>
/// Responsável pelas inicializações relacionadas à nave focada em defesa do jogador.
/// </summary>
public class PlayerDefenderConstructor : PlayerConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.3f;
    attackController.baseShootPower = 1;
  }

  protected override void setUpLife () {
    lifeController._hp = 12;
    lifeController.baseShield = 24;
    lifeController.baseRegeneration = 2;
    base.setUpLife();
    lifeController.shieldRegenerationDelayTimer.baseTime = 2;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController._baseSpeed *= 35;
    movementController.screenLimits.minimumX = -26;
    movementController.screenLimits.maximumX = 26;
    movementController.screenLimits.minimumY = -34;
    movementController.screenLimits.maximumY = 36;
  }

  #endregion

}
