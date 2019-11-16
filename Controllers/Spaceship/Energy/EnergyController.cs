using UnityEngine;

public abstract class EnergyController : MonoBehaviour {

  #region Variáveis

  protected float _shieldMultiplier, _speedMultiplier, _weaponMultiplier;
  protected AttackController attackController;
  public LifeController lifeController { get; set; }
  protected MovementController movementController;

  #endregion

  #region Getters e Setters

  public abstract float shieldMultiplier { get; set; }
  public abstract float speedMultiplier { get; set; }
  public abstract float weaponMultiplier { get; set; }

  #endregion

  #region Métodos da Unity

  protected virtual void Start () {
    attackController = GetComponent<AttackController>();
    lifeController = GetComponent<LifeController>();
    movementController = GetComponent<MovementController>();
  }

  #endregion

  #region Meus Métodos

  protected virtual void updateSpaceshipShieldStatus () {
    lifeController.maxShield = lifeController.baseShield * (_shieldMultiplier / 50);
  }

  protected void updateSpaceshipSpeedStatus () {
    movementController.actualSpeed = movementController.baseSpeed * (_speedMultiplier / 50);
  }

  protected void updateSpaceshipWeaponStatus () {
    attackController.actualShootPower = attackController.baseShootPower * (_weaponMultiplier / 50);
  }

  #endregion
}
