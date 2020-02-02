using UnityEngine;

/// <summary>
/// Classe responsável por inicializar o boss focado em velocidade.
/// </summary>
public class BossEnemyDodgerConstructor : BossEnemyConstructor {

  #region Getters e Setters

  public new BossEnemyDodgerAttackController attackController {
    get => (BossEnemyDodgerAttackController) _attackController;
  }

  public new BossEnemyDodgerMovementController movementController {
    get => (BossEnemyDodgerMovementController) _movementController;
  }

  #endregion

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(1, 3);
    attackController.specialShootTimer = gameObject.AddComponent<Timer>();
    attackController.shootVelocity = 80;
    attackController.baseShootPower = 4;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.speedMultiplier = Random.Range(120, 160);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = energyController.totalEnergy / 2;
    energyController.weaponMultiplier = energyController.totalEnergy / 2;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hp = 20;
    lifeController.baseShield = 40;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegeneration = 1;
    lifeController.actualRegeneration = lifeController.baseRegeneration;
    lifeController.shieldRegenerationDelayTimer.baseTime = 3.33f;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.specialRotation = Quaternion.Euler(90, 0, 0);
    movementController._startingPosition = new Vector3(0, 0, 0);
    movementController.movementTimer = gameObject.AddComponent<Timer>();
    movementController.orbit = Instantiate(movementController.orbit);
    movementController.movementZone = movementController.orbit.GetComponentInChildren<BoxCollider>();
    movementController._baseSpeed = 20;
    movementController.movementTypeTimer.baseTime = 15;
    movementController.movementTypeTimer.time = 0;//
    movementController.movementTimer.baseTime = 3;

  }

  protected override void setUpScore () {
    //scoreReward = 2;
  }

  #endregion
}
