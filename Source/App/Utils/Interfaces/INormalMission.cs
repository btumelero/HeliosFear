using UnityEngine;

/// <summary>
/// Contém as interfaces usadas no projeto
/// </summary>
namespace Interfaces {

  /// <summary>
  /// Contém as interfaces usadas em missões no projeto
  /// </summary>
  namespace Missions {

    /// <summary>
    /// Interface implementada pelas missões normais
    /// </summary>
    public interface INormalMission {

      /// <summary>
      /// A nave do jogador
      /// </summary>
      GameObject player { get; set; }

      /// <summary>
      /// O controlador de movimento do jogador
      /// </summary>
      PlayerMovementController playerMovementController { get; }

      /// <summary>
      /// Estágio pré-missão
      /// </summary>
      void preNormalMission ();

      /// <summary>
      /// Estágio missão
      /// </summary>
      void normalMission ();

      /// <summary>
      /// Estágio pós-missão
      /// </summary>
      void postNormalMission ();

    }

  }
}
