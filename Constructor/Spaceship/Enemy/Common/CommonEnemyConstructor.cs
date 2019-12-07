using UnityEngine;

public abstract class CommonEnemyConstructor : EnemyConstructor {

  #region Getters e Setters

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected new CommonEnemyMovementController movementController {
    get => (CommonEnemyMovementController) _movementController;
    set => _movementController = value;
  }

  #endregion

  #region Meus Métodos

  public virtual void reconstruct () {
    reconstructableAttackVars();
    reconstructableLifeVars();
    reconstructableMovementVars();
    reconstructableEnergyVars();
  }

  protected abstract void reconstructableAttackVars ();

  protected virtual void reconstructableEnergyVars () {
    energyController.totalEnergy = 150;
  }

  protected virtual void reconstructableLifeVars () {
    lifeController.dead = false;
  }

  protected abstract void reconstructableMovementVars ();

  /**
   * Inicializa o ataque
   */
  protected override void setUpAttack () {
    base.setUpAttack();
    reconstructableAttackVars();
  }

  /**
   * Inicializa a energia
   */
  protected override void setUpEnergy () {
    base.setUpEnergy();
    reconstructableEnergyVars();
  }

  /**
   * Inicializa a vida
   */
  protected override void setUpLife () {
    base.setUpLife();
    reconstructableLifeVars();
  }

  /**
   * Inicializa o movimento
   */
  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.spaceshipBody = GetComponentInChildren<Rigidbody>();
    movementController.switchTimer = gameObject.AddComponent<FixedTimer>();
    reconstructableMovementVars();
  }

  #endregion
}
