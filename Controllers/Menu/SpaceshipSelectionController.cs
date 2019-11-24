using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipSelectionController : SpaceshipMenuController {

  public static GameObject spaceship;
  public GameObject[] spaceshipsPrefabs;
  private enum spaceshipsEnum : byte { ATTACKER, DEFENDER, DODGER, NORMAL }

  /*
   * Troca pra fase de sobrevivência quando o usuário escolhe uma das naves
   */
  public void clickedButton () {
    spaceship = spaceshipsPrefabs[chosenType(typeof(spaceshipsEnum))];
    SceneManager.LoadScene("SpaceshipCustomization");
  }

  public override void loadLastScene () {
    SceneManager.LoadScene("Menu");
  }
}
