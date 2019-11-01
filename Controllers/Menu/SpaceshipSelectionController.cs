using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceshipSelectionController : MonoBehaviour {

  public static GameObject spaceship;
  public GameObject[] spaceshipsPrefabs;
  private Dictionary<string, GameObject> spaceships;

  private void Start () {
    spaceships = new Dictionary<string, GameObject> {
       { "PlayerAttacker", spaceshipsPrefabs[0] },
       { "PlayerDefender", spaceshipsPrefabs[1] },
       { "PlayerDodger", spaceshipsPrefabs[2] },
       { "PlayerNormal", spaceshipsPrefabs[3] }
    };
  }

  /*
   * Troca pra fase de sobrevivência quando o usuário escolhe uma das naves
   */
  public void clickedButton () {
    spaceship = spaceships["Player" + EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text];
    SceneManager.LoadScene("Survival");
  }

  public void loadMenu () {
    SceneManager.LoadScene("Menu");
  }
}
