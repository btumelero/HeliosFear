using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SpaceshipMenuController : MenuController {

  public byte chosenType (Type type) {
    return (byte) Enum.Parse(type, EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
  }

}
