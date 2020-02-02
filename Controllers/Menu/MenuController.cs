using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Classe responsável pelo gerenciamento de menus
/// </summary>
public abstract class MenuController : MonoBehaviour {

  #region Meus Métodos

  /// <summary>
  /// Retorna o tipo conforme o botão clicado
  /// </summary>
  /// 
  /// <param name="type">
  /// O tipo do enum
  /// </param>
  /// 
  /// <param name="selectedButton">
  /// O texto do botão clicado
  /// </param>
  /// 
  /// <returns>
  /// O tipo do botão clicado
  /// </returns>
  public byte chosenType (Type type, string selectedButton) {
    return (byte) Enum.Parse(type, selectedButton);
  }

  /// <summary>
  /// Retorna o texto do botão clicado
  /// </summary>
  /// 
  /// <returns>
  /// O texto do botão clicado
  /// </returns>
  public string getSelectedButtonText () {
    return EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
  }

  /// <summary>
  /// Volta à tela anterior
  /// </summary>
  public abstract void exitScene ();

  /// <summary>
  /// Avança para a próxima tela
  /// </summary>
  public abstract void nextScene ();

  #endregion
}
