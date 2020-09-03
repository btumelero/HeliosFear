using System.Collections;

using Assets.Source.App.Utils.Coroutines;

using UnityEngine;

/// <summary>
/// Contém as interfaces relacionadas ao movimento de objetos no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Movements {

  /// <summary>
  /// Interface implementada por naves que possuem movimentação especial/complexa
  /// </summary>
  public interface ISpecialMovement : IMovement {

    /// <summary>
    /// A posição especial da nave
    /// </summary>
    Vector3? specialPosition { get; set; }

    /// <summary>
    /// A movimentação especial da nave
    /// </summary>
    IEnumerator specialMovement ();

    /// <summary>
    /// Alterna para a movimentação especial
    /// </summary>
    IEnumerator switchMovements (IEnumerator previousCoroutine);

  }

}