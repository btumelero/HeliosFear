using UnityEngine.SceneManagement;

public class SurvivalMissionController : MissionController {

  #region Meus Métodos

  public override void postNormalMission () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }

  #endregion

}
