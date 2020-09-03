using System.Collections;

using Assets.Source.App.Utils.Coroutines;

/// <summary>
/// Contém as interfaces usadas em ataques no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Attacks {

  /// <summary>
  /// Interface implementada pelos objetos que têm um ataque normal
  /// </summary>
  public interface IAttack {

    CoroutineController normalAttackCoroutine { get; }

    /// <summary>
    /// O método de ataque normal do objeto
    /// </summary>
    IEnumerator normalAttack ();

  }

}