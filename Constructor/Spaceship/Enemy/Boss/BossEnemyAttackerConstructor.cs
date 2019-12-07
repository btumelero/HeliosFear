using UnityEngine;

public class BossEnemyAttackerConstructor : EnemyConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(1, 3);
    attackController.shootVelocity = 40;
    attackController.baseShootPower = 16;
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
    lifeController.hp = 30;
    lifeController.baseShield = 60;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 1.5f;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.switchTimer.baseTime = Random.Range(3, 5);
    movementController.baseSpeed = 125;
  }

  protected override void setUpScore () {
    //scoreReward = 2;
  }

  #endregion
}
