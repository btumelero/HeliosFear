using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe responsável por simular um radioGroup com botões
/// </summary>
public class ButtonGroup : ToggleGroup {

  #region Variáveis

  /// <summary>
  /// Os botões que aparecem na tela
  /// </summary>
  private Toggle[] toggles;

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Método chamado quando um botão do grupo é clicado
  /// </summary>
  public void buttonClicked () {
    for (byte i = 0; i < toggles.Length; i++) {
      updateColor(toggles[i]);
    }
  }

  /// <summary>
  /// Atualiza a cor dos botões do grupo, destacando o clicado
  /// </summary>
  /// 
  /// <param name="toggle">
  /// O botão clicado
  /// </param>
  private void updateColor (Toggle toggle) {
    toggle.image.fillCenter = toggle.isOn;
    toggle.GetComponentInChildren<Text>().color = toggle.isOn ? Color.black : Color.white;
  }

  /// <summary>
  /// Bloqueia/Desbloqueia os botões conforme as conquistas alcançadas
  /// </summary>
  private void lockUnlockButtons () {
    for (byte i = 1; i < toggles.Length; i++) {
      toggles[i].interactable = AchievementController.isUnlocked(
        toggles[i].GetComponentInChildren<Text>().text + name + "Unlocked"
      );
    }
  }

  /// <summary>
  /// Seleciona automáticamente a melhor opção de customização entre as disponíveis
  /// </summary>
  private void selectBestOption () {
    for (byte i = (byte) (toggles.Length - 1); i >= 0; i--) {
      if (toggles[i].IsInteractable()) {
        toggles[i].Select();
        toggles[i].isOn = true;
        break;
      }
    }
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicializações apenas
  /// </summary>
  protected override void Start () {
    toggles = GetComponentsInChildren<Toggle>();
    lockUnlockButtons();
    selectBestOption();
  }

  #endregion

}
