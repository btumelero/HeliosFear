using Assets.Source.App.Utils.Enums;

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Assets.Source.App.Utils.Extensions {

  /// <summary>
  /// Extensões simples para classes diversas
  /// </summary>
  public static class Game {

    public static GameObject findWithTag (Tags tag) {
      return GameObject.FindGameObjectWithTag(tag.ToString());
    }

    public static void loadScene (Scenes scene) {
      SceneManager.LoadScene(scene.ToString());
    }

  }

}