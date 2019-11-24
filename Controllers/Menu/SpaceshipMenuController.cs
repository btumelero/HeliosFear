using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SpaceshipMenuController : MonoBehaviour {

  public byte chosenType (Type type) {
    return (byte) Enum.Parse(type, EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text.ToUpper());
  }

  public abstract void loadLastScene ();
}
