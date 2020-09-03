using Assets.Source.App.Data.Mission;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.App.Controllers.Spaceship.Life {

  /// <summary>
  /// Classe responsável pelo controle da vida do jogador
  /// </summary>
  public class PlayerLifeController : LifeController {

    #region Campos

    /// <summary>
    /// O slider do hp que aparece na tela
    /// </summary>
    [HideInInspector] public Slider hpSlider;

    /// <summary>
    /// O slide do escudo que aparece na tela
    /// </summary>
    [HideInInspector] public Slider shieldSlider;

    #endregion

    #region Propriedades

    public override float baseShield =>
      base.baseShield * (0.5f + PlayerData.shieldStrength / 2)
    ;

    public override float baseRegeneration =>
      base.baseRegeneration * (0.5f + PlayerData.shieldStrength / 2)
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Destrói a nave caso ela esteja morta.
    /// Isso é feito aqui para evitar que a nave seja destruída antes que outra parte do código tente modificar alguma coisa
    /// </summary>
    protected override void onDeath () {
      Destroy(gameObject);
    }

    /// <summary>
    /// Atualiza os sliders da tela quando o hp for modificado
    /// </summary>
    public override void onHpValueChange () {
      if (hpSlider != null) {
        hpSlider.value = hp.Value;
      }
      base.onHpValueChange();
    }

    /// <summary>
    /// Atualiza os sliders da tela quando o escudo for modificado
    /// </summary>
    public override void onShieldValueChange () {
      base.onShieldValueChange();
      if (shieldSlider != null && dead == false) {
        shieldSlider.value = shield.Value;
      }
    }

    /// <summary>
    /// Garante que o escudo máximo não fique menor que zero e 
    /// que a nave não tenha mais escudo que o máximo permitido.
    /// Além disso, atualiza os slider da tela.
    /// </summary>
    public void onMaxShieldValueChange () {
      maxShield._Value = maxShield.Value >= 0f ? maxShield.Value : 0;
      shield.Value = Mathf.Clamp(shield.Value, 0, maxShield.Value);
      shieldSlider.value = shield.Value;
      shieldSlider.maxValue = maxShield.Value;
    }

    #endregion

  }
}
