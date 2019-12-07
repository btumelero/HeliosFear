using UnityEngine;

public class CommonEnemyNormalConstructor : EnemyConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(2, 5);
    attackController.shootVelocity = 30;
    attackController.baseShootPower = 3;// 6/2
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.speedMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.shieldMultiplier;
    energyController.weaponMultiplier = energyController.totalEnergy;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hp = 4;
    lifeController.baseShield = 8;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 1;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.baseSpeed = 150;
    movementController.switchTimer.baseTime = Random.Range(2, 5);
  }

  protected override void setUpScore () {
    scoreReward = 2;
  }

  #endregion

}
