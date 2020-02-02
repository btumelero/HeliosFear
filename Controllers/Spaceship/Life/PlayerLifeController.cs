using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe responsável pelo controle da vida do jogador
/// </summary>
public class PlayerLifeController : LifeController {

  #region Variáveis

  /// <summary>
  /// O slider do hp que aparece na tela
  /// </summary>
  public Slider hpSlider { get; set; }

  /// <summary>
  /// O slide do escudo que aparece na tela
  /// </summary>
  public Slider shieldSlider { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Garante que o escudo máximo não fique menor que zero e que a nave não tenha mais escudo que o máximo permitido.
  /// Além disso, atualiza os slider da tela.
  /// </summary>
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

  /// <summary>
  /// Destrói a nave caso ela esteja morta.
  /// Isso é feito aqui para evitar que a nave seja destruída antes que outra parte do código tente modificar alguma coisa
  /// </summary>
  protected override void Update () {
    base.Update();
    if (dead) {
      Destroy(gameObject);
    }
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Atualiza os sliders da tela quando o hp for modificado
  /// </summary>
  protected override void onHpValueChange () {
    hpSlider.value = hp;
    base.onHpValueChange();
  }

  /// <summary>
  /// Atualiza os sliders da tela quando o escudo for modificado
  /// </summary>
  protected override void onShieldValueChange () {
    base.onShieldValueChange();
    if (shieldSlider != null) {
      shieldSlider.value = shield;
    }
  }

  #endregion

}
