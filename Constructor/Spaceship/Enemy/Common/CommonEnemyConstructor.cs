using UnityEngine;

/// <summary>
/// Responsável pelas inicializações relacionadas às naves inimigas comuns.
/// </summary>
public abstract class CommonEnemyConstructor : EnemyConstructor {

  #region Getters e Setters

  protected new CommonEnemyMovementController movementController {
    get => (CommonEnemyMovementController) _movementController;
    //set => _movementController = value;
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

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.attack = attackController.normalAttack;
    reconstructableAttackVars();
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    reconstructableEnergyVars();
  }

  protected override void setUpLife () {
    base.setUpLife();
    reconstructableLifeVars();
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.spaceshipBody = GetComponentInChildren<Rigidbody>();
    movementController.switchTimer = gameObject.AddComponent<FixedTimer>();
    reconstructableMovementVars();
  }

  #endregion
}
