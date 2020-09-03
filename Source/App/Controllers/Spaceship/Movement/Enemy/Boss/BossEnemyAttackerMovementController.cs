using System.Collections;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Boss {

  /// <summary>
  /// Classe responsável por gerenciar a movimentação do boss focado em ataque
  /// </summary>
  public class BossEnemyAttackerMovementController : BossEnemyMovementController {

    #region Meus métodos

    /// <summary>
    /// 
    /// </summary>
    public override IEnumerator normalMovement () {
      return null;
    }

    /// <summary>
    /// 
    /// </summary>
    public override IEnumerator specialMovement () {
      return null;
    }

    public override IEnumerator switchMovements (IEnumerator previousCoroutine) {
      return null;
    }

    /// <summary>
    /// 
    /// </summary>
    private void switchToNormalMovement () {

    }

    private void switchToSpecialMovement () {

    }



    #endregion
  }
}
