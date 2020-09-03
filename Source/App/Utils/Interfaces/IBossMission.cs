using System.Collections;

using Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Boss;

using UnityEngine;

/// <summary>
/// Contém as interfaces usadas em missões no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Missions {

  /// <summary>
  /// Interface implementada pelas missões de boss
  /// </summary>
  public interface IBossMission {

    /// <summary>
    /// Estágio pré-boss da missão
    /// </summary>
    IEnumerator onBossMissionStart ();

    /// <summary>
    /// Estágio boss da missão
    /// </summary>
    IEnumerator onBossMission ();

    /// <summary>
    /// Estágio pós-boss da missão
    /// </summary>
    IEnumerator onBossMissionEnd ();

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

  }

}