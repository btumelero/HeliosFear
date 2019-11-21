using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceshipCustomizationController : MonoBehaviour {

  public static byte weaponCount, shieldStrength, engineStrength;
  public enum type : byte { BASIC = 1, ADVANCED = 2, SPECIAL = 3}

  public void weaponButton () {
    weaponCount = chosenType();
  }

  public void engineButton () {
    shieldStrength = chosenType();
  }

  public void shieldButton () {
    engineStrength = chosenType();
  }

  public byte chosenType () {
    return (byte) Enum.Parse(typeof(type), EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text.ToUpper());
  }

  /*
   * Troca pra fase de sobrevivência quando o usuário clica em começar
   */
  public void loadBattle () {
    SceneManager.LoadScene("Survival");
  }

  public void loadMenu () {
    SceneManager.LoadScene("Menu");
  }
}
