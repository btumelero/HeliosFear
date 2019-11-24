using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

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

  private void setLocked (string key) {
    if (PlayerPrefs.HasKey(key) == false) {
      PlayerPrefs.SetInt(key, 0);
    }
  }

  private void Start () {
    setLocked("AdvancedEngineUnlocked");
    setLocked("SpecialEngineUnlocked");
    setLocked("AdvancedShieldUnlocked");
    setLocked("SpecialShieldUnlocked");
    setLocked("AdvancedWeaponUnlocked");
    setLocked("SpecialWeaponUnlocked");
  }
}
