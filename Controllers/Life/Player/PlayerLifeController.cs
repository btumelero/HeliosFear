using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerLifeController : LifeController {

  #region Variáveis

  private Slider hpSlider, shieldSlider;

  #endregion

  #region Getters e Setters

  public override float hp {
    get => _hp;
    set {
      _hp = value;
      hpSlider.value = hp;
      if (_hp <= 0) {
        dead = true;
      }
    }
  }

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

  /*
   * Start is called before the first frame update
   * Inicializações apenas
   */
  protected override void Start () {
    base.Start();
    hpSlider = GameObject.FindGameObjectWithTag("RemainingHpSlider").GetComponent<Slider>();
    shieldSlider = GameObject.FindGameObjectWithTag("RemainingShieldSlider").GetComponent<Slider>();
    regenerationTimer = gameObject.AddComponent<DynamicTimer>();
    hpSlider.maxValue = hp;
    maxShield = baseShield;
    shield = baseShield;
  }

  #endregion

  #region Meus Métodos

  protected override void onShieldValueChange () {
    base.onShieldValueChange();
    shieldSlider.value = shield;
  }

  #endregion

}
