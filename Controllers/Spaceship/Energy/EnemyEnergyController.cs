public class EnemyEnergyController : EnergyController {

  #region Váriaveis

  public float totalEnergy;

  #endregion

  #region Getters e Setters

  public override float shieldMultiplier {
    get => _shieldMultiplier;
    set {
      _shieldMultiplier = value;
      updateSpaceshipShieldStatus();
    }
  }

  public override float speedMultiplier {
    get => _speedMultiplier;
    set {
      _speedMultiplier = value;
      updateSpaceshipSpeedStatus();
    }
  }
  public override float weaponMultiplier {
    get => _weaponMultiplier;
    set {
      _weaponMultiplier = value;
      updateSpaceshipWeaponStatus();
    }
  }

  #endregion

  #region Meus Métodos

  protected override void updateSpaceshipShieldStatus () {
    base.updateSpaceshipShieldStatus();
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed * (_shieldMultiplier / 50);
  }

  #endregion
}
