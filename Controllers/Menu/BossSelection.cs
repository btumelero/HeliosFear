using UnityEngine.SceneManagement;

public class BossSelection : MenuController {

  public override void exitScene () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }

  public override void nextScene () {
    Mission.missionName = getSelectedButtonText();
    SceneManager.LoadScene(Enums.Scenes.SpaceshipSelection.ToString());
  }

}
