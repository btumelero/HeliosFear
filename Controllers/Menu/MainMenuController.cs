using System;
using System.Collections.Generic;

using Enums;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MenuController {

  private Dictionary<string, Scenes> missions;

  /**
   * Troca pro menu de escolha da nave quando o usuário clicar no respectivo botão do menu
   */
  public override void nextScene () {
    Mission.missionName = getSelectedButtonText().Split(' ')[0];
    SceneManager.LoadScene(missions[Mission.missionName].ToString());
  }

  /**
   * Sai do jogo quando o usuário clicar no respectivo botão do menu
   */
  public override void exitScene () {
    Application.Quit();
  }

  private void Start () {
    missions = new Dictionary<string, Scenes>() {
      { Missions.Tutorial.ToString(), Scenes.SpaceshipSelection },
      { Missions.Survival.ToString(), Scenes.SpaceshipSelection },
      { "Boss", Scenes.BossSelection}
    };
  }

}
