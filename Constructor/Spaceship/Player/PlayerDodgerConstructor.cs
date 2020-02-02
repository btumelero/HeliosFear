/// <summary>
/// Responsável pelas inicializações relacionadas à nave focada em velocidade do jogador.
/// </summary>
public class PlayerDodgerConstructor : PlayerConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.25f;
    attackController.baseShootPower = 1.5f;
  }

  protected override void setUpLife () {
    lifeController._hp = 4;
    lifeController.baseShield = 8;
    lifeController.baseRegeneration = 0.5f;
    base.setUpLife();
    lifeController.shieldRegenerationDelayTimer.baseTime = 0.67f;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController._baseSpeed *= 60;
    movementController.screenLimits.minimumX = -28;
    movementController.screenLimits.maximumX = 28;
    movementController.screenLimits.minimumY = -36;
    movementController.screenLimits.maximumY = 38;
  }

  #endregion

}
