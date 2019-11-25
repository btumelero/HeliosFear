using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : ToggleGroup {

  #region Variáveis

  private Toggle[] toggles;

  #endregion

  #region Meus Métodos

  public void buttonClicked () {
    for (byte i = 0; i < toggles.Length; i++) {
      updateColor(toggles[i]);
    }
  }

  private void updateColor (Toggle toggle) {
    toggle.image.fillCenter = toggle.isOn;
    toggle.GetComponentInChildren<Text>().color = toggle.isOn ? Color.black : Color.white;
  }


  private void lockUnlockButtons () {
    for (byte i = 1; i < toggles.Length; i++) {
      toggles[i].interactable = AchievementController.isUnlocked(toggles[i].GetComponentInChildren<Text>().text + name + "Unlocked");
    }
  }

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

  protected override void Start () {
    toggles = GetComponentsInChildren<Toggle>();
    lockUnlockButtons();
    selectBestOption();
  }

  #endregion

}
