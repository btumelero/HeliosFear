using System;

using UnityEngine;

/// <summary>
/// Contém todas as interfaces usadas em builders no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Builders {

  /// <summary>
  /// 
  /// </summary>
  public interface IBuilder {

    /// <summary>
    /// O objeto que será construido pelo builder
    /// </summary>
    GameObject objectToBuild { get; set; }

    /// <summary>
    /// Deve retornar todas as ações necessárias para construir o objeto
    /// </summary>
    /// 
    /// <returns>
    /// Uma ação contendo todos os passos para construir o objeto
    /// </returns>
    Action getActions ();

    /// <summary>
    /// Deve conter a inicialização de campos do builder através do uso de GetComponent em objectToBuild  
    /// </summary>
    /// 
    /// <param name="objectToBuild">
    /// O Objeto do qual o builder irá pegar os componentes
    /// </param>
    void onBuild (GameObject objectToBuild);

  }

}