using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCustomizationController : SpaceshipMenuController {

  #region Variáveis

  public static byte weaponCount, shieldStrength, engineStrength;
  public enum type : byte { BASIC = 1, ADVANCED = 2, SPECIAL = 3 }

  #endregion

  #region Meus Métodos

  public void weaponButton () {
    weaponCount = chosenType(typeof(type));
  }

  public void engineButton () {
    shieldStrength = chosenType(typeof(type));
  }

  public void shieldButton () {
    engineStrength = chosenType(typeof(type));
  }

  public void cheatButton () {
    PlayerPrefs.SetInt("AdvancedEngineUnlocked", Convert.ToInt32(!Convert.ToBoolean(PlayerPrefs.GetInt("AdvancedEngineUnlocked"))));
    PlayerPrefs.SetInt("SpecialEngineUnlocked", Convert.ToInt32(!Convert.ToBoolean(PlayerPrefs.GetInt("SpecialEngineUnlocked"))));
    PlayerPrefs.SetInt("AdvancedShieldUnlocked", Convert.ToInt32(!Convert.ToBoolean(PlayerPrefs.GetInt("AdvancedShieldUnlocked"))));
    PlayerPrefs.SetInt("SpecialShieldUnlocked", Convert.ToInt32(!Convert.ToBoolean(PlayerPrefs.GetInt("SpecialShieldUnlocked"))));
    PlayerPrefs.SetInt("AdvancedWeaponUnlocked", Convert.ToInt32(!Convert.ToBoolean(PlayerPrefs.GetInt("AdvancedWeaponUnlocked"))));
    PlayerPrefs.SetInt("SpecialWeaponUnlocked", Convert.ToInt32(!Convert.ToBoolean(PlayerPrefs.GetInt("SpecialWeaponUnlocked"))));
  }

  /*
   * Troca pra fase de sobrevivência quando o usuário clica em começar
   */
  public void loadBattle () {
    SceneManager.LoadScene("Survival");
  }

  public override void loadLastScene () {
    SceneManager.LoadScene("SpaceshipSelection");
  }

  #endregion

}