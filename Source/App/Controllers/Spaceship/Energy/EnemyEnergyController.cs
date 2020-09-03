/// <summary>
/// Controla o comportamento da energia das naves inimigas
/// </summary>
public class EnemyEnergyController : EnergyController {

  #region Váriaveis

  /// <summary>
  /// O total de energia que a nave tem
  /// </summary>
  public float totalEnergy;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Guarda o valor na variável e chama o método que atualiza o valor atual do escudo inimigo
  /// </summary>
  public override float shieldMultiplier {
    get => _shieldMultiplier;
    set {
      _shieldMultiplier = value;
      updateSpaceshipShieldStatus();
    }
  }

  /// <summary>
  /// Guarda o valor na variável e chama o método que atualiza o valor atual da velocidade inimiga
  /// </summary>
  public override float speedMultiplier {
    get => _speedMultiplier;
    set {
      _speedMultiplier = value;
      updateSpaceshipSpeedStatus();
    }
  }

  /// <summary>
  /// Guarda o valor na variável e chama o método que atualiza o valor atual do dano inimigo
  /// </summary>
  public override float weaponMultiplier {
    get => _weaponMultiplier;
    set {
      _weaponMultiplier = value;
      updateSpaceshipWeaponStatus();
    }
  }

  #endregion

}
