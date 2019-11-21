using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceshipSelectionController : MonoBehaviour {

  public static GameObject spaceship;
  public GameObject[] spaceshipsPrefabs;
  public enum spaceshipsEnum : byte { ATTACKER, DEFENDER, DODGER, NORMAL }

  /*
   * Troca pra fase de sobrevivência quando o usuário escolhe uma das naves
   */
  public void clickedButton () {
    spaceshipsEnum prefab = (spaceshipsEnum) Enum.Parse(typeof(spaceshipsEnum), EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text.ToUpper());
    spaceship = spaceshipsPrefabs[(byte) prefab];
    SceneManager.LoadScene("Survival");
  }

  public void loadMenu () {
    SceneManager.LoadScene("Menu");
  }
}
