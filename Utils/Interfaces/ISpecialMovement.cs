using UnityEngine;

/// <summary>
/// Contém as interfaces usadas no projeto
/// </summary>
namespace Interfaces {

  /// <summary>
  /// Contém as interfaces relacionadas ao movimento de objetos no projeto
  /// </summary>
  namespace Movements {

    /// <summary>
    /// Interface implementada por naves que possuem movimentação especial/complexa
    /// </summary>
    public interface ISpecialMovement : IMovement {

      /// <summary>
      /// A posição especial da nave
      /// </summary>
      Vector3 specialPosition { get; }

      /// <summary>
      /// A movimentação especial da nave
      /// </summary>
      void specialMovement ();

      /// <summary>
      /// Alterna para a movimentação especial
      /// </summary>
      void switchToSpecialMovement ();

      /// <summary>
      /// Alterna para a movimentação normal
      /// </summary>
      void switchToNormalMovement ();

    }

  }

}
