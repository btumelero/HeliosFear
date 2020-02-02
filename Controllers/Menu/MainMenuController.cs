using System.Collections.Generic;

using Enums;

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsável por gerenciar o menu principal
/// </summary>
public class MainMenuController : MenuController {

  #region Variáveis

  /// <summary>
  /// Relaciona missão-cena e é usado para decidir a cena a ser carregada
  /// </summary>
  private Dictionary<string, Scenes> missions;

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Avança para a próxima tela
  /// </summary>
  public override void nextScene () {
    Mission.missionName = getSelectedButtonText().Split(' ')[0];
    SceneManager.LoadScene(missions[Mission.missionName].ToString());
  }

  /// <summary>
  /// Volta à tela anterior
  /// </summary>
  public override void exitScene () {
    Application.Quit();
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicialização apenas
  /// </summary>
  private void Start () {
    missions = new Dictionary<string, Scenes>() {
      { Missions.Tutorial.ToString(), Scenes.SpaceshipSelection },
      { Missions.Survival.ToString(), Scenes.SpaceshipSelection },
      { "Boss", Scenes.BossSelection}
    };
  }

  #endregion

}
