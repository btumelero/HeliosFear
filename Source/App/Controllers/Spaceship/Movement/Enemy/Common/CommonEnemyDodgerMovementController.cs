using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common {

  /// <summary>
  /// Classe responsável por gerenciar a movimentação do inimigo rápido
  /// </summary>
  public class CommonEnemyDodgerMovementController : CommonEnemyMovementController {

    #region Meus métodos

    /// <summary>
    /// Esse tipo de nave se move para esquerda e direita.
    /// Esse método randomiza entre os dois
    /// </summary>
    public override void switchMovementDirection () {
      moving.Value = Random.Range(0, 2) * 2 - 1;
    }

    /// <summary>
    /// Atualiza a direção em que a nave está indo
    /// </summary>
    public override void onMovingValueChanged () {
      spaceshipBody.velocity = new Vector3(
        x: (Time.fixedDeltaTime * 3) * moving.Value,
        y: (Time.fixedDeltaTime * 3) * -actualSpeed
      );
    }

    #endregion

  }
}
