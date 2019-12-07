using UnityEngine;

public class BossEnemyDodgerConstructor : BossEnemyConstructor {

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.shootTimer.baseTime = Random.Range(1, 3);
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
    lifeController.baseRegenerationSpeed = 1;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController._baseSpeed = 200;
  }

  protected override void setUpScore () {
    //scoreReward = 2;
  }

  #endregion
}
