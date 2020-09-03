using System.Linq;

using Assets.Source.App.Controllers.Other;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.App.UI {

  /// <summary>
  /// Classe responsável por simular um radioGroup com botões
  /// </summary>
  public class ButtonGroup : ToggleGroup {

    #region Métodos da Unity

    protected override void Start () {
      m_Toggles = m_Toggles.OrderBy(toggle => toggle.name).ToList();
      updateButtonGroup();
    }

    #endregion

    #region Meus Métodos

    #region Inicialização / Atualização da UI

    public void updateButtonGroup () {
      lockUnlockButtons();
      selectBestOption();
      onClick();
    }

    /// <summary>
    /// Seleciona automáticamente a melhor opção de customização entre as disponíveis
    /// </summary>
    private void selectBestOption () {
      for (int i = m_Toggles.Count - 1; i >= 0; i--) {//reverse iteration
        if (m_Toggles[i].IsInteractable()) {
          m_Toggles[i].Select();
          m_Toggles[i].isOn = true;
          break;
        }
      }
    }

    #endregion

    #region Trapaças

    /// <summary>
    /// Bloqueia/Desbloqueia os botões conforme as conquistas alcançadas
    /// </summary>
    private void lockUnlockButtons () {
      for (int i = 1; i < m_Toggles.Count; i++) {
        m_Toggles[i].interactable = isUnlocked(m_Toggles[i]);
      }
    }

    private bool isUnlocked (Toggle toggle) {
      return AchievementController.isUnlocked(
        $"{toggle.GetComponentInChildren<Text>().text}{name}Unlocked"
      );
    }

    #endregion

    #region Clique

    public byte getClickedButton () {
      for (byte i = 0; i < m_Toggles.Count; i++) {
        if (m_Toggles[i].isOn) {
          return ++i;
        }
      }
      return 0;
    }

    /// <summary>
    /// Método chamado quando um botão do grupo é clicado
    /// </summary>
    public void onClick () {
      m_Toggles.ForEach(updateColor);
    }

    /// <summary>
    /// Atualiza a cor dos botões do grupo, destacando o clicado
    /// </summary>
    /// 
    /// <param name="toggle">
    /// O botão clicado
    /// </param>
    private void updateColor (Toggle toggle) {
      toggle.GetComponentInChildren<Image>().fillCenter = toggle.isOn;
      toggle.GetComponentInChildren<Text>().color = toggle.isOn ? Color.black : Color.white;
    }

    #endregion

    #endregion

  }
}
