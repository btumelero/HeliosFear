using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeController : LifeController {

  #region Variáveis

  public Slider hpSlider { get; set; }
  public Slider shieldSlider { get; set; }

  #endregion

  #region Getters e Setters

  public override float hp {
    get => _hp;
    set {
      _hp = value;
      hpSlider.value = hp;
      onHpValueChange();
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
   * Acaba o jogo caso o player tenha morrido
   */
  private void OnDestroy () {
    GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
    if (canvas != null) {
      MissionController missionController = canvas.GetComponent<MissionController>();
      if (missionController != null) {
        missionController.enabled = false;
      }
    }
  }

  #endregion

  #region Meus Métodos

  protected override void onHpValueChange () {
    if (hp <=0) {
      
      dead = true;
    }
  }

  protected override void onShieldValueChange () {
    base.onShieldValueChange();
    shieldSlider.value = shield;
  }

  #endregion

}
