using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common {

  /// <summary>
  /// Classe responsável por gerenciar a movimentação do inimigo normal
  /// </summary>
  public class CommonEnemyNormalMovementController : CommonEnemyMovementController {

    #region Meus métodos

    /// <summary>
    /// Esse tipo de nave se move para esquerda, direita e baixo.
    /// Esse método randomiza entre as três.
    /// </summary>
    public override void switchMovementDirection () {
      moving.Value = Random.Range(-1, 2);
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
