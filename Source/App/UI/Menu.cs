using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Contém todas as classes responsáveis por controlar a interface do usuário
/// </summary>
namespace Assets.Source.App.UI {

  /// <summary>
  /// Classe base responsável controlar a interface do usuário
  /// </summary>
  public abstract class Menu : MonoBehaviour {

    /// <summary>
    /// Retorna o texto do botão clicado
    /// </summary>
    /// 
    /// <returns>
    /// O texto do botão clicado
    /// </returns>
    protected string getSelectedButtonText () {
      return EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
    }

  }
}