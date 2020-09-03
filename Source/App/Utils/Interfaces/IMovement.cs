using System.Collections;

using Assets.Source.App.Utils.Coroutines;

using UnityEngine;

/// <summary>
/// Contém as interfaces relacionadas ao movimento de objetos no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Movements {

  /// <summary>
  /// Interface implementada por naves que possuem padrões menos básicos de movimentação
  /// </summary>
  public interface IMovement {

    #region Propriedades

    /// <summary>
    /// A velocidade real da nave
    /// </summary>
    float actualSpeed { get; }

    CoroutineController movementCoroutine { get; }

    /// <summary>
    /// A nave
    /// </summary>
    GameObject gameObject { get; }

    /// <summary>
    /// A posição inicial da nave
    /// </summary>
    Vector3 startingPosition { get; }

    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// A movimentação normal da nave
    /// </summary>
    IEnumerator normalMovement ();

    #endregion

  }

}