using System.Collections;

using Assets.Source.App.Utils.Extensions;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Attack.Enemy.Common {

  /// <summary>
  /// Controla o comportamento de ataque da nave focada em defesa
  /// </summary>
  public class CommonEnemyDefenderAttackController : CommonEnemyAttackController {

    #region Meus Métodos

    /// <summary>
    /// Esse tipo de nave atira um tiro na direção do jogador
    /// </summary>
    public override IEnumerator normalAttack () {
      while (true) {
        shoot(weapons[0], this.getPlayerDirection(weapons[0]));
        yield return new WaitForSeconds(shootTimer);
      }
    }

    #endregion

  }
}