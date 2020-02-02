﻿using UnityEngine;

/// <summary>
/// Responsável pelas inicializações relacionadas à nave inimiga focada em defesa.
/// </summary>
public class CommonEnemyDefenderConstructor : CommonEnemyConstructor {

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   */
  protected override void Start () {
    base.Start();
    movementController.moving = Enums.Movement.Downward;
  }

  #endregion

  #region Meus Métodos

  public override void reconstruct () {
    base.reconstruct();
    movementController.moving = Enums.Movement.Downward;
  }

  protected override void reconstructableAttackVars () {
    attackController.shootTimer.baseTime = Random.Range(3, 6);
    attackController.shootVelocity = 20;
    attackController.baseShootPower = 4;
  }

  protected override void reconstructableLifeVars () {
    base.reconstructableLifeVars();
    lifeController.hp = 6;
    lifeController.baseShield = 12;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.shield = lifeController.baseShield;
    lifeController.baseRegeneration = 1.5f;
    lifeController.actualRegeneration = lifeController.baseRegeneration;
  }

  protected override void reconstructableEnergyVars () {
    base.reconstructableEnergyVars();
    energyController.shieldMultiplier = Random.Range(60, 80);
    energyController.totalEnergy -= energyController.shieldMultiplier;
    energyController.speedMultiplier = Random.Range(40, 60);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.weaponMultiplier = energyController.totalEnergy;
  }

  protected override void reconstructableMovementVars () {
    movementController.switchTimer.baseTime = Random.Range(3, 6);
    movementController._baseSpeed = 100;
  }

  protected override void setUpScore () {
    lifeController.scoreReward = 4;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.shieldRegenerationDelayTimer.baseTime = 2;
  }
  #endregion
}
