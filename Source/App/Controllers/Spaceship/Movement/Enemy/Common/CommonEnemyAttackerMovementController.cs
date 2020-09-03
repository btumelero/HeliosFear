using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Enums;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common {

  /// <summary>
  /// Classe responsável por gerenciar a movimentação do inimigo focado em ataque
  /// </summary>
  public class CommonEnemyAttackerMovementController : CommonEnemyMovementController {

    #region Propriedades

    /// <summary>
    /// A nave do jogador
    /// </summary>
    public GameObject player => 
      PlayerData.spaceship
    ;

    #endregion

    #region Meus métodos

    /// <summary>
    /// Esse tipo de nave se move para baixo e na direção horizontal do jogador
    /// </summary>
    public override void switchMovementDirection () {
      if (player != null) {
        float playerX = player.transform.position.x;
        moving.Value =
          transform.position.x < playerX - 1.5f ?
            (int) Movements.Rightward
            :
          transform.position.x > playerX + 1.5f ?
            (int) Movements.Leftward
            :
            (int) Movements.Downward
        ;
      } else {
        moving.Value = (int) Movements.Downward;
      }
    }

    /// <summary>
    /// Atualiza a direção em que a nave está indo
    /// </summary>
    public override void onMovingValueChanged () {
      spaceshipBody.velocity = new Vector3(
        x: (Time.fixedDeltaTime * 3) * (moving.Value * actualSpeed),
        y: (Time.fixedDeltaTime * 3) * -actualSpeed
      );
    }

    #endregion

  }
}
