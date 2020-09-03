using Assets.Source.App.Utils.Enums;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.App.Controllers.Spaceship.Energy {

  /// <summary>
  /// Controla o comportamento da energia da nave do jogador
  /// </summary>
  public class PlayerEnergyController : EnergyController {

    #region Campos

    /// <summary>
    /// Referência do slider do escudo que aparece na tela
    /// </summary>
    [HideInInspector] public Slider shieldSlider;

    /// <summary>
    /// Referência do slider da velocidade que aparece na tela
    /// </summary>
    [HideInInspector] public Slider speedSlider;

    /// <summary>
    /// Referência do slider do dano que aparece na tela
    /// </summary>
    [HideInInspector] public Slider weaponSlider;

    /// <summary>
    /// O quanto por vez o slider vai aumentar/diminuir
    /// </summary>
    public int step;

    #endregion

    #region Eventos

    public void onValueChange (Sliders slider) {
      onValueChange(slider, Input.GetAxis(slider.ToString()));
    }

    #endregion

    #region Meus Métodos

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
    private void onValueChange (Sliders except, float input) {
      float tempStep = step;
      Sliders multiplier;
      for (int i = 0; i < 2; i++) {
        for (byte j = 0; j < 3 && tempStep > 0; j++) {
          multiplier = (Sliders) j;
          if (multiplier != except) {
            if (isModifiable(multipliers[multiplier, raw: true], -input)) {
              multipliers[multiplier, raw: true] += step * -input / 2;
              tempStep -= step / 2;
            }
          }
        }
      }
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
    private bool multiplierWillBeModified (Sliders slider) {
      return (
        Input.GetButtonDown(slider.ToString()) || Input.GetButton(slider.ToString())) &&
        isModifiable(multipliers[slider, raw: true], Input.GetAxis(slider.ToString())
      );
    }

    /// <summary>
    /// Retorna verdadeiro se o jogador apertou o botão pra modificar a energia destinada à button 
    /// e atualiza os multiplicadores da nave
    /// </summary>
    /// 
    /// <param name="button">
    /// O botão a ser checado
    /// </param>
    /// 
    /// <param name="slider">
    /// O multiplicador equivalente
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se o jogador apertou o botão e o multiplicador foi modificado
    /// </returns>
    private bool isPressedAndModifiable (Sliders slider) {
      if (multiplierWillBeModified(slider)) {
        multipliers[slider, raw: true] += Input.GetAxis(slider.ToString()) * step;
        return true;
      }
      return false;
    }

    /// <summary>
    /// Atualiza os slider da energia da nave na tela
    /// </summary>
    private void updateSliders () {
      shieldSlider.value = multipliers[Sliders.Shield, raw: true];
      speedSlider.value = multipliers[Sliders.Speed, raw: true];
      weaponSlider.value = multipliers[Sliders.Weapon, raw: true];
    }

    /// <summary>
    /// Atualiza todos os status da nave e os sliders da energia na tela
    /// </summary>
    public override void updateSpaceshipStatus () {
      base.updateSpaceshipStatus();
      updateSliders();
    }

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Atualiza os status da nave se um dos botões tiver sido apertado e 
    /// os multiplicadores tiverem sido alterados.
    /// </summary>
    private void Update () {
      if (
        isPressedAndModifiable(Sliders.Shield) ||
        isPressedAndModifiable(Sliders.Speed) ||
        isPressedAndModifiable(Sliders.Weapon)
      ) {
        updateSpaceshipStatus();
      }
    }

    #endregion

  }
}
