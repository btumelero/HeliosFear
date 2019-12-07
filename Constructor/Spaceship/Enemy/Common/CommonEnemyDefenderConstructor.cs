using UnityEngine;

public class CommonEnemyDefenderConstructor : EnemyConstructor {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa o score que vai ser dado pro jogador caso ele destrua essa nave
   */
  protected override void Start () {
    base.Start();
    movementController.moving = Enums.Movement.Downward;
  }

  #endregion

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(3, 6);
    attackController.shootVelocity = 20;
    attackController.baseShootPower = 4;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.shieldMultiplier = Random.Range(60, 80);
    energyController.totalEnergy -= energyController.shieldMultiplier;
    energyController.speedMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.weaponMultiplier = energyController.totalEnergy;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hp = 6;
    lifeController.baseShield = 12;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 1.5f;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.switchTimer.baseTime = Random.Range(3, 6);
    movementController.baseSpeed = 100;
  }

  protected override void setUpScore () {
    scoreReward = 4;
  }

  #endregion
}
