/**
 * Responsável pelas inicializações de variáveis relacionadas à nave focada em defesa do jogador.
 */
 public class PlayerDefenderConstructor : PlayerConstructor {

  #region Meus Métodos

  /**
   * Inicializa o ataque
   */
  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.3f;
    attackController.baseShootPower = 1;
  }

  /**
   * Inicializa a vida
   */
  protected override void setUpLife () {
    lifeController._hp = 12;
    lifeController.baseShield = 24;
    lifeController.baseRegenerationSpeed = 2;
    base.setUpLife();
  }

  /**
   * Inicializa o movimento
   */
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
