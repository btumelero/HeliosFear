using UnityEngine;
using UnityEngine.UI;

/**
 * Controla o comportamento da energia da nave do jogador
 */
public class PlayerEnergyController : EnergyController {

  #region Váriaveis

  /**
   * Referência do slider do escudo que aparece na tela
   */
  public Slider shieldSlider { get; set; }

  /**
   * Referência do slider da velocidade que aparece na tela
   */
  public Slider speedSlider { get; set; }

  /**
   * Referência do slider do dano que aparece na tela
   */
  public Slider weaponSlider { get; set; }

  /**
   * O quanto por vez o slider vai aumentar/diminuir
   */
  public int step;

  #endregion

  #region Getters e Setters

  /**
   * Guarda o valor na variável e chama o método que atualiza os outros dois valores 
   */
  public override float shieldMultiplier {
    get => _shieldMultiplier;
    set {
      _shieldMultiplier = value;
      onValueChange(ref _speedMultiplier, ref _weaponMultiplier, Input.GetAxis(Enums.Input.Shield.ToString()));
    }
  }

  /**
   * Guarda o valor na variável e chama o método que atualiza os outros dois valores 
   */
  public override float speedMultiplier {
    get => _speedMultiplier;
    set {
      _speedMultiplier = value;
      onValueChange(ref _shieldMultiplier, ref _weaponMultiplier, Input.GetAxis(Enums.Input.Speed.ToString()));
    }
  }

  /**
   * Guarda o valor na variável e chama o método que atualiza os outros dois valores 
   */
  public override float weaponMultiplier {
    get => _weaponMultiplier;
    set {
      _weaponMultiplier = value;
      onValueChange(ref _shieldMultiplier, ref _speedMultiplier, Input.GetAxis(Enums.Input.Weapon.ToString()));
    }
  }

  #endregion

  #region Meus métodos

  /**
   * Se for possível, diminui os dois valores passados por parâmetro
   */
  private void onValueChange (ref float valueOne, ref float valueTwo, float input) {
    bool valueOneIsModifiable = isModifiable(valueOne, -input);
    bool valueTwoIsModifiable = isModifiable(valueTwo, -input);
    float tempValue = step;
    do {
      if (valueOneIsModifiable) {
        valueOne += step * -input / 2;
        tempValue -= step / 2;
      }
      if (valueTwoIsModifiable) {
        valueTwo += step * -input / 2;
        tempValue -= step / 2;
      }
    } while (tempValue > 0);
  }

  /**
   * Checa se um valor pode ser modificado (0-100)
   */
  private bool isModifiable (float multiplier, float modification) {
    return (multiplier < 100 && modification > 0) || (multiplier > 0 && modification < 0);
  }

  /**
   * Checa se o botão passado por parâmetro foi apertado e se o multiplicador pode ser modificado
   */
  private bool multiplierModified (string button, float multiplier) {
    return (Input.GetButtonDown(button) || Input.GetButton(button)) && isModifiable(multiplier, Input.GetAxis(button));
  }

  /**
   * Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada ao escudo e 
   * atualiza os multiplicadores da nave
   */
  private bool shieldMultiplierModified () {
    if (multiplierModified(Enums.Input.Shield.ToString(), shieldMultiplier)) {
      shieldMultiplier += Input.GetAxis(Enums.Input.Shield.ToString()) * step;
      return true;
    }
    return false;
  }

  /**
   * Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada à velocidade e
   * atualiza os multiplicadores da nave
   */
  private bool speedMultiplierModified () {
    if (multiplierModified(Enums.Input.Speed.ToString(), speedMultiplier)) {
      speedMultiplier += Input.GetAxis(Enums.Input.Speed.ToString()) * step;
      return true;
    }
    return false;
  }

  /**
   * Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada às armas 
   * atualiza os multiplicadores da nave
   */
  private bool weaponMultiplierModified () {
    if (multiplierModified(Enums.Input.Weapon.ToString(), weaponMultiplier)) {
      weaponMultiplier += Input.GetAxis(Enums.Input.Weapon.ToString()) * step;
      return true;
    }
    return false;
  }

  /**
   * Atualiza os slider da energia da nave na tela
   */
  private void updateSliders () {
    shieldSlider.value = _shieldMultiplier;
    speedSlider.value = _speedMultiplier;
    weaponSlider.value = _weaponMultiplier;
  }

  /**
   * Atualiza todos os status da nave e os sliders da energia na tela
   */
  public void updateSpaceshipStatus () {
    updateSpaceshipShieldStatus();
    updateSpaceshipSpeedStatus();
    updateSpaceshipWeaponStatus();
    updateSliders();
  }

  #endregion

  #region Métodos da Unity

  /**
   * Atualiza os status da nave se os multiplicadores tiverem sido alterados
   */
  private void Update () {
    if (shieldMultiplierModified() || speedMultiplierModified() || weaponMultiplierModified()) {
      updateSpaceshipStatus();
    }
  }

  #endregion

}
