using Enums;

using UnityEngine;
using UnityEngine.SceneManagement;

using Input = UnityEngine.Input;

/// <summary>
/// Classe responsável por gerenciar a missão tutorial
/// </summary>
public class TutorialMissionController : MonoBehaviour {

  #region Getters e Setters

  /// <summary>
  /// A nave do jogador
  /// </summary>
  public GameObject player {
    get => Mission.spaceship;
    set => Mission.spaceship = value;
  }

  #endregion

  /// <summary>
  /// Inicialização apenas
  /// </summary>
  private void Start () {
    player = Instantiate(Mission.spaceship);
  }

  /// <summary>
  /// Sai do tutorial ao apertar ESC
  /// </summary>
  private void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }
  }
}
