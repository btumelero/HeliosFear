using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeController : LifeController {

  #region Variáveis

  public Slider hpSlider { get; set; }
  public Slider shieldSlider { get; set; }

  #endregion

  #region Getters e Setters

  public override float maxShield {
    get => _maxShield;
    set {
      _maxShield = value;
      _maxShield = _maxShield >= 0 ? _maxShield : 0;
      shield = Mathf.Clamp(shield, 0, maxShield);
      shieldSlider.maxValue = maxShield;
      shieldSlider.value = shield;
    }
  }

  #endregion

  #region Métodos da Unity

  protected override void Update () {
    base.Update();
    if (dead) {
      Destroy(gameObject);
    }
  }

  #endregion

  #region Meus Métodos

  protected override void onHpValueChange () {
    hpSlider.value = hp;
    base.onHpValueChange();
  }

  protected override void onShieldValueChange () {
    base.onShieldValueChange();
    if (shieldSlider != null) {
      shieldSlider.value = shield;
    }
  }

  #endregion

}
