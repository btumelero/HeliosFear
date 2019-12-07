using UnityEngine;

public class CommonEnemyAttackerConstructor : EnemyConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(1, 4);
    attackController.shootVelocity = 20;
    attackController.baseShootPower = 8;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.weaponMultiplier = Random.Range(60, 80);
    energyController.totalEnergy -= energyController.weaponMultiplier;
    energyController.speedMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = energyController.totalEnergy;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hp = 3;
    lifeController.baseShield = 6;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 0.75f;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.switchTimer.baseTime = Random.Range(3, 5);
    movementController.baseSpeed = 125;
  }

  protected override void setUpScore () {
    scoreReward = 4;
  }

  #endregion

}
