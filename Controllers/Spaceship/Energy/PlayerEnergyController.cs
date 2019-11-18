﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyController : EnergyController {

  #region Váriaveis

  private Slider shieldSlider, speedSlider, weaponSlider;
  private int step;

  #endregion

  #region Getters e Setters

  public override float shieldMultiplier {
    get => _shieldMultiplier;
    set {
      _shieldMultiplier = value;
      onValueChange(ref _speedMultiplier, ref _weaponMultiplier, Input.GetAxis("Shield"));
    }
  }

  public override float speedMultiplier {
    get => _speedMultiplier;
    set {
      _speedMultiplier = value;
      onValueChange(ref _shieldMultiplier, ref _weaponMultiplier, Input.GetAxis("Speed"));
    }
  }

  public override float weaponMultiplier {
    get => _weaponMultiplier;
    set {
      _weaponMultiplier = value;
      onValueChange(ref _shieldMultiplier, ref _speedMultiplier, Input.GetAxis("Weapon"));
    }
  }

  #endregion

  #region Meus métodos

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

  private bool isModifiable (float multiplier, float modification) {
    return (multiplier < 100 && modification > 0) || (multiplier > 0 && modification < 0);
  }

  private bool multiplierModified (string button, float multiplier) {
    return (Input.GetButtonDown(button) || Input.GetButton(button)) && isModifiable(multiplier, Input.GetAxis(button));
  }

  /*
   * Se o jogador apertou o botão pra modificar a energia destinada ao escudo, 
   * então atualiza os multiplicadores da nave e retorna verdadeiro
   */
  private bool shieldMultiplierModified () {
    if (multiplierModified("Shield", shieldMultiplier)) {
      shieldMultiplier += Input.GetAxis("Shield") * step;
      return true;
    }
    return false;
  }

  /*
   * Se o jogador apertou o botão pra modificar a energia destinada à velocidade, 
   * então atualiza os multiplicadores da nave e retorna verdadeiro
   */
  private bool speedMultiplierModified () {
    if (multiplierModified("Speed", speedMultiplier)) {
      speedMultiplier += Input.GetAxis("Speed") * step;
      return true;
    }
    return false;
  }

  /*
   * Se o jogador apertou o botão pra modificar a energia destinada às armas, 
   * então atualiza os multiplicadores da nave e retorna verdadeiro
   */
  private bool weaponMultiplierModified () {
    if (multiplierModified("Weapon", weaponMultiplier)) {
      weaponMultiplier += Input.GetAxis("Weapon") * step;
      return true;
    }
    return false;
  }

  private void updateSliders () {
    shieldSlider.value = _shieldMultiplier;
    speedSlider.value = _speedMultiplier;
    weaponSlider.value = _weaponMultiplier;
  }

  protected override void updateSpaceshipShieldStatus () {
    base.updateSpaceshipShieldStatus();
    DynamicTimer dynamicRegenerationTimer = lifeController.regenerationTimer as DynamicTimer;
    dynamicRegenerationTimer.actualTime = dynamicRegenerationTimer.baseTime * (_shieldMultiplier / 50);
  }

  private void updateSpaceshipStatus () {
    updateSpaceshipShieldStatus();
    updateSpaceshipSpeedStatus();
    updateSpaceshipWeaponStatus();
    updateSliders();
  }

  #endregion

  #region Métodos da Unity

  /*
   * Se os multiplicadores tiverem sido alterados, então atualiza os status da nave
   */
  private void Update () {
    if (shieldMultiplierModified() || speedMultiplierModified() || weaponMultiplierModified()) {
      updateSpaceshipStatus();
    }
  }

  /*
   * Start is called before the first frame update
   * Pega a referência dos sliders na tela, dos controllers do player e inicializa os multiplicadores
   */
  protected override void Start () {
    base.Start();
    shieldSlider = GameObject.FindGameObjectWithTag("ShieldSlider").GetComponent<Slider>();
    speedSlider = GameObject.FindGameObjectWithTag("SpeedSlider").GetComponent<Slider>();
    weaponSlider = GameObject.FindGameObjectWithTag("WeaponSlider").GetComponent<Slider>();
    _shieldMultiplier = 50;
    _speedMultiplier = 50;
    _weaponMultiplier = 50;
    step = 6;
    updateSpaceshipStatus();
  }

  #endregion

}