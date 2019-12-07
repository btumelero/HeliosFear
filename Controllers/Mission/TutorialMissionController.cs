using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = UnityEngine.Input;

public class TutorialMissionController : MonoBehaviour {

  #region Variáveis


  #endregion

  #region Getters e Setters

  public GameObject player {
    get => Mission.spaceship;
    set => Mission.spaceship = value;
  }

  #endregion

  // Start is called before the first frame update
  private void Start () {
    player = Instantiate(Mission.spaceship);
  }

  // Update is called once per frame
  private void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }
  }
}
