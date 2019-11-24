using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : ToggleGroup {

  #region Variáveis

  private Toggle[] toggles;

  #endregion

  #region Meus Métodos

  public void buttonClicked () {
    for (int i = 0; i < toggles.Length; i++) {
      setSelected(toggles[i]);
    }
  }

  private void setSelected (Toggle toggle) {
    toggle.image.fillCenter = toggle.isOn;
    toggle.GetComponentInChildren<Text>().color = toggle.isOn ? Color.black : Color.white;
  }

  private bool isUnlocked (string key) {
    return
      PlayerPrefs.HasKey(key) ?
        Convert.ToBoolean(PlayerPrefs.GetInt(key))
        :
        false
    ;
  }
  private void updateButtons () {
    for (int i = 1; i < toggles.Length; i++) {
      toggles[i].interactable = isUnlocked(toggles[i].GetComponentInChildren<Text>().text + name + "Unlocked");
    }
  }

  private void selectBestCustomizations () {
    for (int i = toggles.Length - 1; i >= 0; i--) {
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
    updateButtons();
    selectBestCustomizations();
  }

  #endregion

}
