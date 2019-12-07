using UnityEngine;

public class CommonEnemyDodgerConstructor : EnemyConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(2, 4);
    attackController.shootVelocity = 40;
    attackController.baseShootPower = 2;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.speedMultiplier = Random.Range(60, 80);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = energyController.totalEnergy / 2;
    energyController.weaponMultiplier = energyController.totalEnergy / 2;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hp = 2;
    lifeController.baseShield = 4;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 0.5f;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.switchTimer.baseTime = Random.Range(2, 4);
    movementController.baseSpeed = 200;
  }

  protected override void setUpScore () {
    scoreReward = 1;
  }

  #endregion
}
