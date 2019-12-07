using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MenuController : MonoBehaviour {

  public byte chosenType (Type type, string selectedButton) {
    return (byte) Enum.Parse(type, selectedButton);
  }

  public string getSelectedButtonText () {
    return EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
  }

  #region Meus Métodos

  public abstract void exitScene ();

  public abstract void nextScene ();

  #endregion
}
