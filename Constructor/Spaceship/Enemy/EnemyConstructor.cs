using UnityEngine;

/**
 * Responsável pelas inicializações de variáveis relacionadas às naves inimigas.
 */
public abstract class EnemyConstructor : SpaceshipConstructor {

  #region Getters e Setters

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected EnemyAttackController attackController {
    get => (EnemyAttackController) _attackController;
  }

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected EnemyEnergyController energyController {
    get => (EnemyEnergyController) _energyController;
  }

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
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

