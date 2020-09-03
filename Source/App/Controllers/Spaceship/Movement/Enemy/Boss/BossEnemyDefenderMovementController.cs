using System.Collections;

using Assets.Source.App.Utils.Extensions;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Boss {

  /// <summary>
  /// Classe responsável por gerenciar a movimentação do boss focado em defesa
  /// </summary>
  public class BossEnemyDefenderMovementController : BossEnemyMovementController {

    #region Minhas Rotinas

    /// <summary>
    /// Sai da tela.
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina.
    /// </returns>
    public override IEnumerator normalMovement () {
      while (this.positionIs(startingPosition) == false) {
        yield return new WaitForFixedUpdate();
        this.moveTowards(startingPosition, actualSpeed);
      }
      movementCoroutine.play(switchMovements(movementCoroutine.coroutine));
    }

    /// <summary>
    /// Entra na tela.
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina.
    ///</returns>
    public override IEnumerator specialMovement () {
      while (this.positionIs(specialPosition.Value) == false) {
        yield return new WaitForFixedUpdate();
        this.moveTowards(specialPosition.Value, actualSpeed);
      }
      movementCoroutine.play(switchMovements(movementCoroutine.coroutine));
    }

    /// <summary>
    /// Alterna entre entrar e sair da tela.
    /// </summary>
    /// 
    /// <param name="previousMovement">
    /// O movimento anterior do boss (se ele entrou ou saiu da tela).
    /// </param>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina.
    /// </returns>
    public override IEnumerator switchMovements (IEnumerator previousMovement) {
      yield return new WaitForSeconds(movementTypeTimer);
      movementCoroutine.play(
        previousMovement.equals(normalMovement()) == true ?
          specialMovement()
          :
          normalMovement()
      );
    }

    #endregion

  }
}
