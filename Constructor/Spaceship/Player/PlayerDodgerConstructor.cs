/**
 * Responsável pelas inicializações de variáveis relacionadas à nave focada em velocidade do jogador.
 */
 public class PlayerDodgerConstructor : PlayerConstructor {

  #region Meus Métodos

  /**
   * Inicializa o ataque
   */
  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.25f;
    attackController.baseShootPower = 1.5f;
  }

  /**
   * Inicializa a vida
   */
  protected override void setUpLife () {
    lifeController._hp = 4;
    lifeController.baseShield = 8;
    lifeController.baseRegenerationSpeed = 0.5f;
    base.setUpLife();
  }

  /**
   * Inicializa o movimento
   */
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
