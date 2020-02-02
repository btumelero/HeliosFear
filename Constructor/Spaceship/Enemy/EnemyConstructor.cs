/// <summary>
/// Responsável pelas inicializações relacionadas às naves inimigas.
/// </summary>
public abstract class EnemyConstructor : SpaceshipConstructor {

  #region Getters e Setters

  protected EnemyAttackController attackController {
    get => (EnemyAttackController) _attackController;
  }

  protected EnemyEnergyController energyController {
    get => (EnemyEnergyController) _energyController;
  }

  protected EnemyLifeController lifeController {
    get => (EnemyLifeController) _lifeController;
  }

  protected EnemyMovementController movementController {
    get => (EnemyMovementController) _movementController;
  }

  #endregion

  #region Meus Métodos

  protected override void setUpMovement () {
    movementController._spaceship = gameObject;
  }

  #endregion

}

