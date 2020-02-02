using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsável por gerenciar a cutomização da nave
/// </summary>
public class SpaceshipCustomizationController : MenuController {

  #region Meus Métodos

  /// <summary>
  /// Método chamado ao clicar em um dos tipos de armas disponíveis
  /// </summary>
  public void weaponButton () {
    Mission.weaponCount = chosenType(typeof(Enums.Customization), getSelectedButtonText());
  }

  /// <summary>
  /// Método chamado ao clicar em um dos tipos de motores disponíveis
  /// </summary>
  public void engineButton () {
    Mission.shieldStrength = chosenType(typeof(Enums.Customization), getSelectedButtonText());
  }

  /// <summary>
  /// Método chamado ao clicar em um dos tipos de escudos disponíveis
  /// </summary>
  public void shieldButton () {
    Mission.engineStrength = chosenType(typeof(Enums.Customization), getSelectedButtonText());
  }

  /// <summary>
  /// Temporário: desbloqueia todas as conquistas
  /// </summary>
  public void cheatButton () {
    AchievementController.lockUnlock();
  }

  /// <summary>
  /// Avança para a próxima tela
  /// </summary>
  public override void nextScene () {
    SceneManager.LoadScene(Enums.Scenes.Battle.ToString());
  }

  /// <summary>
  /// Volta à tela anterior
  /// </summary>
  public override void exitScene () {
    SceneManager.LoadScene(Enums.Scenes.SpaceshipSelection.ToString());
  }

  #endregion

}