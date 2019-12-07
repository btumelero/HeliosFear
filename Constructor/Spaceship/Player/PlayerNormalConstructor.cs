/**
 * Responsável pelas inicializações de variáveis relacionadas à nave normal do jogador.
 */
 public class PlayerNormalConstructor : PlayerConstructor {

  #region Meus Métodos

  /**
   * Inicializa o ataque
   */
  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = 0.2f;
    attackController.baseShootPower = 2;
  }

  /**
   * Inicializa a vida
   */
  protected override void setUpLife () {
    lifeController._hp = 8;
    lifeController.baseShield = 16;
    lifeController.baseRegenerationSpeed = 1;
    base.setUpLife();
  }

  /**
   * Inicializa o movimento
   */
  protected override void setUpMovement () {
    base.setUpMovement();
    movementController._baseSpeed *= 45;
    movementController.screenLimits.minimumX = -28;
    movementController.screenLimits.maximumX = 28;
    movementController.screenLimits.minimumY = -35;
    movementController.screenLimits.maximumY = 37;
  }

  #endregion

}
