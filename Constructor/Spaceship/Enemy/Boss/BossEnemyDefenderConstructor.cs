﻿using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Classe responsável por inicializar o boss focado em defesa
/// </summary>
public class BossEnemyDefenderConstructor : BossEnemyConstructor {

  protected new BossEnemyDefenderAttackController attackController {
    get => (BossEnemyDefenderAttackController) _attackController;
  }

  protected new BossEnemyDefenderMovementController movementController {
    get => (BossEnemyDefenderMovementController) _movementController;
  }

  #region Meus Métodos

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.specialShootTimer = gameObject.AddComponent<Timer>();
    attackController.specialShootTimer.enabled = false;
    attackController.shootTimer.baseTime = Random.Range(1, 3);
    attackController.shootVelocity = 40;
    attackController.baseShootPower = 4;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.shieldMultiplier = Random.Range(120, 160);
    energyController.totalEnergy -= energyController.shieldMultiplier;
    energyController.speedMultiplier = Random.Range(80, 120);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.weaponMultiplier = energyController.totalEnergy;
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hp = 60;
    lifeController.baseShield = 120;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.shield = lifeController.baseShield;
    lifeController.baseRegeneration = 3;
    lifeController.actualRegeneration = lifeController.baseRegeneration;
    lifeController.shieldRegenerationDelayTimer.baseTime = 10;
  }

  protected override void setUpMovement () {
    base.setUpMovement();
    movementController._baseSpeed = 7.5f;
    movementController._startingPosition = new Vector3(0, 22, 0);
    movementController.offscreenPosition = new Vector3(0, 65, 0);
    movementController.specialPosition = new Vector3(0, 65, -25);
    movementController.movementList = new List<Vector3>();
    transform.position = movementController.specialPosition;
    movementController.movementTypeTimer.baseTime = 15;
    movementController.movementTypeTimer.time = 0;
  }

  protected override void setUpScore () {
    //scoreReward = 2;
  }

  #endregion
}
