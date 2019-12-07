/**
 * Controla o comportamento da energia das naves inimigas
 */
public class EnemyEnergyController : EnergyController {

  #region Váriaveis

  /**
   * O total de energia que a nave tem
   */
  public float totalEnergy;

  #endregion

  #region Getters e Setters

  /**
   * Guarda o valor na variável e chama o método que atualiza o valor atual do escudo inimigo
   */
  public override float shieldMultiplier {
    get => _shieldMultiplier;
    set {
      _shieldMultiplier = value;
      updateSpaceshipShieldStatus();
    }
  }

  /**
   * Guarda o valor na variável e chama o método que atualiza o valor atual da velocidade inimiga
   */
  public override float speedMultiplier {
    get => _speedMultiplier;
    set {
      _speedMultiplier = value;
      updateSpaceshipSpeedStatus();
    }
  }

  /**
   * Guarda o valor na variável e chama o método que atualiza o valor atual do dano inimigo
   */
  public override float weaponMultiplier {
    get => _weaponMultiplier;
    set {
      _weaponMultiplier = value;
      updateSpaceshipWeaponStatus();
    }
  }

  #endregion

}
