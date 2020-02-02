using UnityEngine;

/// <summary>
/// Responsável pelas inicializações relacionadas à nave inimiga focada em ataque.
/// </summary>
public class CommonEnemyAttackerConstructor : CommonEnemyConstructor {

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
    attackController.shootTimer.baseTime = Random.Range(1, 4);
    attackController.shootVelocity = 20;
    attackController.baseShootPower = 8;
  }

  protected override void reconstructableEnergyVars () {
    base.reconstructableEnergyVars();
    energyController.weaponMultiplier = Random.Range(60, 80);
    energyController.totalEnergy -= energyController.weaponMultiplier;
    energyController.speedMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = energyController.totalEnergy;
  }

  protected override void reconstructableLifeVars () {
    base.reconstructableLifeVars();
    lifeController.hp = 3;
    lifeController.baseShield = 6;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.shield = lifeController.baseShield;
    lifeController.baseRegeneration = 0.75f;
    lifeController.actualRegeneration = lifeController.baseRegeneration;
  }

  protected override void reconstructableMovementVars () {
    movementController.switchTimer.baseTime = Random.Range(3, 5);
    movementController._baseSpeed = 125;
  }

  protected override void setUpScore () {
    lifeController.scoreReward = 4;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.shieldRegenerationDelayTimer.baseTime = 1;
  }

  #endregion

}
