using System.Collections;

using Assets.Source.App.Utils.Coroutines;

/// <summary>
/// Contém as interfaces usadas em ataques no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Attacks {

  /// <summary>
  /// Interface implementada pelos objetos que possuem ataques especias
  /// </summary>
  public interface ISpecialAttack : IAttack {

    CoroutineController specialAttackCoroutine { get; }

    /// <summary>
    /// O método de ataque especial do objeto
    /// </summary>
    IEnumerator specialAttack ();

  }

}
