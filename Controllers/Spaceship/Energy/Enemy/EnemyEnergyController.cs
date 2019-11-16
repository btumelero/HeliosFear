public abstract class EnemyEnergyController : EnergyController {

  #region Váriaveis

  protected float totalEnergy { get; set; }

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

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa a energia total dos inimigos
   */
  protected override void Start () {
    base.Start();
    totalEnergy = 150;
  }

  #endregion

  #region Meus Métodos

  protected override void updateSpaceshipShieldStatus () {
    base.updateSpaceshipShieldStatus();
    lifeController.regenerationTimer.baseTime *= (_shieldMultiplier / 50);
  }

  #endregion
}
