using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipSelectionController : MenuController {
  
  public GameObject[] spaceshipsPrefabs;

  /*
   * Troca pra fase de sobrevivência quando o usuário escolhe uma das naves
   */
  public override void nextScene () {
    Mission.spaceship = spaceshipsPrefabs[chosenType(typeof(Enums.Spaceships), getSelectedButtonText())];
    SceneManager.LoadScene(Enums.Scenes.SpaceshipCustomization.ToString());
  }

  public override void exitScene () {
    SceneManager.LoadScene(
      Mission.missionName.Equals(Enums.Missions.Survival.ToString()) ?
        Enums.Scenes.MainMenu.ToString()
        :
        Enums.Scenes.BossSelection.ToString()
    );
  }
}
