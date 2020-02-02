using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsável por gerenciar o menu de escolha do boss a enfrentar
/// </summary>
public class BossSelection : MenuController {

  #region Meus Métodos

  /// <summary>
  /// Volta à tela anterior
  /// </summary>
  public override void exitScene () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }

  /// <summary>
  /// Avança para a próxima tela
  /// </summary>
  public override void nextScene () {
    Mission.missionName = getSelectedButtonText();
    SceneManager.LoadScene(Enums.Scenes.SpaceshipSelection.ToString());
  }

  #endregion

}
