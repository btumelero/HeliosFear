using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCustomizationController : SpaceshipMenuController {

  #region Variáveis

  public static byte weaponCount, shieldStrength, engineStrength;

  #endregion

  #region Meus Métodos

  public void weaponButton () {
    weaponCount = chosenType(typeof(Enums.Customization));
  }

  public void engineButton () {
    shieldStrength = chosenType(typeof(Enums.Customization));
  }

  public void shieldButton () {
    engineStrength = chosenType(typeof(Enums.Customization));
  }

  public void cheatButton () {
    AchievementController.lockUnlock();
  }

  /*
   * Troca pra fase de sobrevivência quando o usuário clica em começar
   */
  public override void nextScene () {
    SceneManager.LoadScene(Enums.Scenes.Survival.ToString());
  }

  public override void exitScene () {
    SceneManager.LoadScene(Enums.Scenes.SpaceshipSelection.ToString());
  }

  #endregion

}