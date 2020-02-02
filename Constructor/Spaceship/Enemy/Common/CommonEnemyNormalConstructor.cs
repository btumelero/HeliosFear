using UnityEngine;

/// <summary>
/// Responsável pelas inicializações  relacionadas à nave inimiga normal.
/// </summary>
public class CommonEnemyNormalConstructor : CommonEnemyConstructor {

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    movementController.directionSwitch();
  }

  #endregion

  #region Meus Métodos

  public override void reconstruct () {
    base.reconstruct();
    movementController.directionSwitch();
  }

  protected override void reconstructableAttackVars () {
    attackController.shootTimer.baseTime = Random.Range(2, 5);
    attackController.shootVelocity = 30;
    attackController.baseShootPower = 3;// 6/2
  }

  protected override void reconstructableEnergyVars () {
    base.reconstructableEnergyVars();
    energyController.speedMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.shieldMultiplier;
    energyController.weaponMultiplier = energyController.totalEnergy;
  }

  protected override void reconstructableLifeVars () {
    base.reconstructableLifeVars();
    lifeController.hp = 4;
    lifeController.baseShield = 8;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.shield = lifeController.baseShield;
    lifeController.baseRegeneration = 1;
    lifeController.actualRegeneration = lifeController.baseRegeneration;
  }

  protected override void reconstructableMovementVars () {
    movementController._baseSpeed = 150;
    movementController.switchTimer.baseTime = Random.Range(2, 5);
  }

  protected override void setUpScore () {
    lifeController.scoreReward = 2;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.shieldRegenerationDelayTimer.baseTime = 1.33f;
  }

  #endregion

}
