using System;
using System.Collections.Generic;

using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contém todas as classes responsáveis por controlar a interface do usuário
/// </summary>
namespace Assets.Source.App.UI {

  /// <summary>
  /// Classe responsável por controlar a navegação entre menus
  /// </summary>
  public class MenuNavigator : Menu {

    #region Campos

    /// <summary>
    /// Botão ou conjunto de botões de um menu
    /// </summary>
    public GameObject boss, cancel, customization, main, spaceship;

    /// <summary>
    /// Dicionário com o texto do botão como chave e a ação a ser realizada ao clicá-lo como valor
    /// </summary>
    private Dictionary<string, Action> navigation;

    /// <summary>
    /// O caminho que o usuário percorreu pelos menus
    /// </summary>
    private Stack<GameObject> path;

    #endregion

    #region Métodos da Unity

    private void Awake () {
      path = new Stack<GameObject>();
      path.Push(main);
      navigation = newNavigation();
    }

    #region Método newNavigation

    /// <summary>
    /// Método de inicialização do dicionário navigation
    /// </summary>
    /// 
    /// <returns>
    /// Um dicionário inicializado
    /// </returns>
    private Dictionary<string, Action> newNavigation () {
      return new Dictionary<string, Action>() {
        //Main Menu
        {
          "Survival", () => navigateFromTo(path.Peek(), spaceship)
        },
        {
          "Boss", () => navigateFromTo(path.Peek(), boss)
        },
        {
          "Tutorial", () => navigateFromTo(path.Peek(), spaceship)
        },
        {
          "Exit", () => Application.Quit()
        },
        //Boss and Spaceship Selection
        {
          "Attacker", () => navigateFromTo(path.Peek(), path.Peek().Equals(boss) ? spaceship : customization)
        },
        {
          "Defender", () => navigateFromTo(path.Peek(), path.Peek().Equals(boss) ? spaceship : customization)
        },
        {
          "Dodger", () => navigateFromTo(path.Peek(), path.Peek().Equals(boss) ? spaceship : customization)
        },
        {
          "Normal", () => navigateFromTo(path.Peek(), customization)
        },
        //Spaceship Customization
        {
          "Start" , () => Game.loadScene(Scenes.Battle)
        },
        //Others
        {
          "Cancel", () => navigateFromTo(path.Pop(), path.Peek())
        },
      };
    }

    #endregion

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Esse método é chamado ao clicar em um botão responsável por carregar outro menu
    /// </summary>
    public void navigate () {
      navigation[getSelectedButtonText()].Invoke();
    }

    /// <summary>
    /// Navega de um menu para outro, escondendo o antigo e exibindo o novo.
    /// Além disso, mantém atualizado o caminho percorrido pelo usuário nos menus
    /// e mostra um botão de voltar quando necessário.
    /// </summary>
    /// 
    /// <param name="from">
    /// O menu que o usuário está agora
    /// </param>
    /// 
    /// <param name="to">
    /// O menu para o qual o usuário irá
    /// </param>
    private void navigateFromTo (GameObject from, GameObject to) {
      from.SetActive(false);
      to.SetActive(true);
      if (path.Peek().Equals(to) == false) {
        path.Push(to);
      }
      cancel.SetActive(to.Equals(main) == false);
    }

    #endregion

  }
}