using Assets.Source.App.Utils.Enums;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common {

  /// <summary>
  /// Classe responsável por gerenciar a movimentação do inimigo focado em defesa
  /// </summary>
  public class CommonEnemyDefenderMovementController : CommonEnemyMovementController {

    #region Meus métodos

    /// <summary>
    /// Esse tipo de nave defender se move para baixo ou fica parada.
    /// Esse método randomiza entre os dois
    /// </summary>
    public override void switchMovementDirection () {
      moving.Value = (Random.Range(0, 2) * 2);
    }

    /// <summary>
    /// Atualiza a direção em que a nave está indo
    /// </summary>
    public override void onMovingValueChanged () {
      spaceshipBody.velocity = new Vector3(
        x: 0,
        y: (Time.fixedDeltaTime * 3) * (moving.Value == (int) Movements.Downward ? -actualSpeed : 0)
      );
    }

    #endregion

  }
}
