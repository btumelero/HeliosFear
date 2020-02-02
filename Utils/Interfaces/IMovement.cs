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
    /// Interface implementada por naves que possuem padrões menos básicos de movimentação
    /// </summary>
    public interface IMovement : IMove {

      /// <summary>
      /// A posição inicial da nave
      /// </summary>
      Vector3 startingPosition { get; }

      /// <summary>
      /// A nave
      /// </summary>
      GameObject spaceship { get; }

      /// <summary>
      /// A movimentação normal da nave
      /// </summary>
      void normalMovement ();

    }

  }
}
