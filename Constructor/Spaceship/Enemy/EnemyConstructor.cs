using UnityEngine;

public abstract class EnemyConstructor : SpaceshipConstructor {

  #region Variáveis

  protected int scoreReward;

  #endregion

  #region Getters e Setters

  protected EnemyAttackController attackController { 
    get => (EnemyAttackController) _attackController; 
    set => _attackController = value; 
  }

  protected EnemyEnergyController energyController { 
    get => (EnemyEnergyController) _energyController; 
    set => _energyController = value;
  }

  protected EnemyLifeController lifeController {
    get => (EnemyLifeController) _lifeController;
    set => _lifeController = value;
  }

  protected EnemyMovementController movementController {
    get => (EnemyMovementController) _movementController;
    set => _movementController = value;
  }

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    movementController.directionSwitch();
  }

  #endregion

  #region Meus Métodos

  /*
   * Provisório: aumenta e salva nas preferências do jogador o highscore dele
   */
  public void giveScore () {
    GameObject player = GameObject.FindGameObjectWithTag(Enums.Tags.Player.ToString());
    if (player != null) {
      PlayerConstructor playerController = player.GetComponentInParent<PlayerConstructor>();
      if (player != null) {
        playerController.score += scoreReward;
      }
    }
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.totalEnergy = 150;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.enemyConstructor = GetComponent<EnemyConstructor>();
  }

  protected override void setUpMovement () {
    movementController.spaceship = GetComponentInChildren<Rigidbody>();
    movementController.switchTimer = gameObject.AddComponent<FixedTimer>();
  }

  #endregion

}

