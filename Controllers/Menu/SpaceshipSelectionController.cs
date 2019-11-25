using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipSelectionController : SpaceshipMenuController {

  public static GameObject spaceship;
  public GameObject[] spaceshipsPrefabs;

  /*
   * Troca pra fase de sobrevivência quando o usuário escolhe uma das naves
   */
  public override void nextScene () {
    spaceship = spaceshipsPrefabs[chosenType(typeof(Enums.Spaceships))];
    SceneManager.LoadScene(Enums.Scenes.SpaceshipCustomization.ToString());
  }

  public override void exitScene () {
    SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
  }
}
