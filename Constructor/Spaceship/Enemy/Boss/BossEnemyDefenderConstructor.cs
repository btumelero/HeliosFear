using UnityEngine;

public class BossEnemyDefenderConstructor : EnemyConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(1, 3);
    attackController.shootVelocity = 40;
    attackController.baseShootPower = 8;
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
    lifeController.hp = 60;
    lifeController.baseShield = 120;
    lifeController.shield = lifeController.baseShield;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 3;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController.switchTimer.baseTime = Random.Range(3, 6);
    movementController.baseSpeed = 100;
  }

  protected override void setUpScore () {
    //scoreReward = 2;
  }

  #endregion
}
