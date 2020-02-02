using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla o comportamento da energia da nave do jogador
/// </summary>
public class PlayerEnergyController : EnergyController {

  #region Váriaveis

  /// <summary>
  /// Referência do slider do escudo que aparece na tela
  /// </summary>
  public Slider shieldSlider { get; set; }

  /// <summary>
  /// Referência do slider da velocidade que aparece na tela
  /// </summary>
  public Slider speedSlider { get; set; }

  /// <summary>
  /// Referência do slider do dano que aparece na tela
  /// </summary>
  public Slider weaponSlider { get; set; }

  /// <summary>
  /// O quanto por vez o slider vai aumentar/diminuir
  /// </summary>
  public int step;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Guarda o valor na variável e chama o método que atualiza os outros dois valores 
  /// </summary>
  public override float shieldMultiplier {
    get => _shieldMultiplier;
    set {
      _shieldMultiplier = value;
      onValueChange(ref _speedMultiplier, ref _weaponMultiplier, Input.GetAxis(Enums.Input.Shield.ToString()));
    }
  }

  /// <summary>
  /// Guarda o valor na variável e chama o método que atualiza os outros dois valores 
  /// </summary>
  public override float speedMultiplier {
    get => _speedMultiplier;
    set {
      _speedMultiplier = value;
      onValueChange(ref _shieldMultiplier, ref _weaponMultiplier, Input.GetAxis(Enums.Input.Speed.ToString()));
    }
  }

  /// <summary>
  /// Guarda o valor na variável e chama o método que atualiza os outros dois valores 
  /// </summary>
  public override float weaponMultiplier {
    get => _weaponMultiplier;
    set {
      _weaponMultiplier = value;
      onValueChange(ref _shieldMultiplier, ref _speedMultiplier, Input.GetAxis(Enums.Input.Weapon.ToString()));
    }
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Ao aumentar o multiplicador de escudo da nave, por exemplo, a velocidade e as armas 
  /// são passadas como parâmetro para esse método que, se for possível, as diminui. 
  /// O mesmo comportamento vale para os outros multiplicadores
  /// </summary>
  /// 
  /// <param name="multiplierOne">
  /// O primeiro multiplicador a ser diminuido
  /// </param>
  /// 
  /// <param name="multiplierTwo">
  /// O segundo multiplicador a ser diminuido
  /// </param>
  /// 
  /// <param name="input">
  /// O quanto o multiplicador deve ser diminuido
  /// </param>
  private void onValueChange (ref float multiplierOne, ref float multiplierTwo, float input) {
    bool valueOneIsModifiable = isModifiable(multiplierOne, -input);
    bool valueTwoIsModifiable = isModifiable(multiplierTwo, -input);
    float tempValue = step;
    do {
      if (valueOneIsModifiable) {
        multiplierOne += step * -input / 2;
        tempValue -= step / 2;
      }
      if (valueTwoIsModifiable) {
        multiplierTwo += step * -input / 2;
        tempValue -= step / 2;
      }
    } while (tempValue > 0);
  }

  /// <summary>
  /// Checa se um multiplicador pode ser modificado (0-100)
  /// </summary>
  /// 
  /// <param name="multiplier">
  /// O modificador a ser checado
  /// </param>
  /// 
  /// <param name="modification">
  /// A modificação a ser feita
  /// </param>
  /// 
  /// <returns>
  /// Verdadeiro se pode ser modificado
  /// </returns>
  private bool isModifiable (float multiplier, float modification) {
    return (multiplier < 100 && modification > 0) || (multiplier > 0 && modification < 0);
  }

  /// <summary>
  /// Checa se o botão passado por parâmetro foi apertado e se o multiplicador pode ser modificado
  /// </summary>
  /// 
  /// <param name="button">
  /// O botão a ser checado
  /// </param>
  /// 
  /// <param name="multiplier">
  /// O multiplicador a ser modificado
  /// </param>
  /// 
  /// <returns>
  /// Verdadeiro se o botão foi apertado e é possivel modificar o multiplicador
  /// </returns>
  private bool multiplierModified (string button, float multiplier) {
    return (Input.GetButtonDown(button) || Input.GetButton(button)) && isModifiable(multiplier, Input.GetAxis(button));
  }

  /// <summary>
  /// Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada ao escudo e 
  /// atualiza os multiplicadores da nave
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o jogador apertou o botão pra modificar o escudo
  /// </returns>
  private bool shieldMultiplierModified () {
    if (multiplierModified(Enums.Input.Shield.ToString(), shieldMultiplier)) {
      shieldMultiplier += Input.GetAxis(Enums.Input.Shield.ToString()) * step;
      return true;
    }
    return false;
  }

  /// <summary>
  /// Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada à velocidade e
  /// atualiza os multiplicadores da nave
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o jogador apertou o botão pra modificar a velocidade
  /// </returns>
  private bool speedMultiplierModified () {
    if (multiplierModified(Enums.Input.Speed.ToString(), speedMultiplier)) {
      speedMultiplier += Input.GetAxis(Enums.Input.Speed.ToString()) * step;
      return true;
    }
    return false;
  }

  /// <summary>
  /// Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada às armas 
  /// atualiza os multiplicadores da nave
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o jogador apertou o botão pra modificar as armas
  /// </returns>
  private bool weaponMultiplierModified () {
    if (multiplierModified(Enums.Input.Weapon.ToString(), weaponMultiplier)) {
      weaponMultiplier += Input.GetAxis(Enums.Input.Weapon.ToString()) * step;
      return true;
    }
    return false;
  }

  /// <summary>
  /// Atualiza os slider da energia da nave na tela
  /// </summary>
  private void updateSliders () {
    shieldSlider.value = _shieldMultiplier;
    speedSlider.value = _speedMultiplier;
    weaponSlider.value = _weaponMultiplier;
  }

  /// <summary>
  /// Atualiza todos os status da nave e os sliders da energia na tela
  /// </summary>
  public void updateSpaceshipStatus () {
    updateSpaceshipShieldStatus();
    updateSpaceshipSpeedStatus();
    updateSpaceshipWeaponStatus();
    updateSliders();
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Atualiza os status da nave se os multiplicadores tiverem sido alterados
  /// </summary>
  private void Update () {
    if (shieldMultiplierModified() || speedMultiplierModified() || weaponMultiplierModified()) {
      updateSpaceshipStatus();
    }
  }

  #endregion

}
