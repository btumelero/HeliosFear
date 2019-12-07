using UnityEngine;

/**
 * Responsável pelas inicializações de variáveis relacionadas à nave inimiga focada em velocidade.
 */
public class CommonEnemyDodgerConstructor : CommonEnemyConstructor {

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
    attackController.shootTimer.baseTime = Random.Range(2, 4);
    attackController.shootVelocity = 40;
    attackController.baseShootPower = 2;
  }

  protected override void reconstructableEnergyVars () {
    base.reconstructableEnergyVars();
    energyController.speedMultiplier = Random.Range(60, 80);
    energyController.totalEnergy -= energyController.speedMultiplier;
    energyController.shieldMultiplier = energyController.totalEnergy / 2;
    energyController.weaponMultiplier = energyController.totalEnergy / 2;
  }

  protected override void reconstructableLifeVars () {
    base.reconstructableLifeVars();
    lifeController.hp = 2;
    lifeController.baseShield = 4;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.shield = lifeController.baseShield;
    lifeController.baseRegenerationSpeed = 0.5f;
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed;
  }

  protected override void reconstructableMovementVars () {
    movementController.switchTimer.baseTime = Random.Range(2, 4);
    movementController._baseSpeed = 200;
  }

  /**
   * Inicializa o score
   */
  protected override void setUpScore () {
    lifeController.scoreReward = 1;
  }

  #endregion

}
