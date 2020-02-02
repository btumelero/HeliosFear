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
    /// Interface implementada pelas missões de boss
    /// </summary>
    public interface IBossMission {

      /// <summary>
      /// O boss da missão
      /// </summary>
      GameObject boss { get; }

      /// <summary>
      /// O controlador do movimento do boss
      /// </summary>
      BossEnemyMovementController bossMovementController { get; }

      /// <summary>
      /// Estágio pré-boss da missão
      /// </summary>
      void postNormalMission ();

      /// <summary>
      /// Estágio boss da missão
      /// </summary>
      void bossMission ();

      /// <summary>
      /// Atualizações no player durante o estágio boss da missão
      /// </summary>
      void updatePlayer ();

      /// <summary>
      /// Atualizações no boss durante o estágio boss da missão
      /// </summary>
      void updateBoss ();

      /// <summary>
      /// Atualizações em outras coisas durante o estágio boss da missão
      /// </summary>
      void updateOthers ();

      /// <summary>
      /// Estágio pós-boss da missão
      /// </summary>
      void postBossMission ();

    }

  }
}
