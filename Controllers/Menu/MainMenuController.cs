using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

  /*
   * Troca pro menu de escolha da nave quando o usuário clicar no respectivo botão do menu
   */
  public void loadSpaceshipSelection () {
    SceneManager.LoadScene("SpaceshipSelection");
  }

  /*
   * Sai do jogo quando o usuário clicar no respectivo botão do menu
   */
  public void exitGame () {
    Application.Quit();
  }

}
