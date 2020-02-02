using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsável pela missão de sobrevivência
/// </summary>
public class SurvivalMissionController : MissionController {

  #region Meus Métodos

  /// <summary>
  /// Volta ao menu principal ao acabar
  /// </summary>
  public override void postNormalMission () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }

  #endregion

}
