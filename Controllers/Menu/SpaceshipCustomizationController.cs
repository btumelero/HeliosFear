using UnityEngine.SceneManagement;

public class SpaceshipCustomizationController : MenuController {

  #region Meus Métodos

  public void weaponButton () {
    Mission.weaponCount = chosenType(typeof(Enums.Customization), getSelectedButtonText());
  }

  public void engineButton () {
    Mission.shieldStrength = chosenType(typeof(Enums.Customization), getSelectedButtonText());
  }

  public void shieldButton () {
    Mission.engineStrength = chosenType(typeof(Enums.Customization), getSelectedButtonText());
  }

  public void cheatButton () {
    AchievementController.lockUnlock();
  }

  /*
   * Troca pra fase de sobrevivência quando o usuário clica em começar
   */
  public override void nextScene () {
    SceneManager.LoadScene(Enums.Scenes.Battle.ToString());
  }

  public override void exitScene () {
    SceneManager.LoadScene(Enums.Scenes.SpaceshipSelection.ToString());
  }

  #endregion

}