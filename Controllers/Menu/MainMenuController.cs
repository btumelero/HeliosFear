using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MenuController {

  /*
   * Troca pro menu de escolha da nave quando o usuário clicar no respectivo botão do menu
   */
  public override void nextScene () {
    SceneManager.LoadScene(Enums.Scenes.SpaceshipSelection.ToString());
  }

  /*
   * Sai do jogo quando o usuário clicar no respectivo botão do menu
   */
  public override void exitScene () {
    Application.Quit();
  }

}
