using System;

using Assets.Source.App.Utils.Interfaces.Builders;

using UnityEngine;

/// <summary>
/// Contém as classes responsáveis por construir objetos do jogo
/// </summary>
namespace Assets.Source.App.Builders {

  /// <summary>
  /// Classe abstrata que os builders estendem. 
  /// Contém o necessário para uma implementação correta de um builder em uma subclasse
  /// </summary>
  /// 
  /// <typeparam name="T">
  /// O tipo de dado que o builder usará pra construir o objeto
  /// </typeparam>
  public abstract class AbstractBuilder<T> : IBuilder where T : IDataGroup {

    /// <summary>
    /// O objeto que será construido pelo builder
    /// </summary>
    public GameObject objectToBuild { get; set; }

    /// <summary>
    /// Deve retornar uma ação com todos os passos necessários para construir o objeto
    /// </summary>
    /// 
    /// <returns>
    /// Uma ação contendo todos os passos para construir o objeto
    /// </returns>
    public abstract Action getActions ();

    /// <summary>
    /// Deve retornar os dados necessários para construir o objeto
    /// </summary>
    public abstract T data { get; }

    /// <summary>
    /// Deve conter a inicialização de campos do builder através do uso de GetComponent em objectToBuild  
    /// </summary>
    /// 
    /// <param name="objectToBuild">
    /// O Objeto do qual o builder irá pegar os componentes
    /// </param>
    public abstract void onBuild (GameObject objectToBuild);

  }

}