using System.Collections;

using Assets.Source.App.Utils.Extensions;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Attack.Enemy.Boss {

  /// <summary>
  /// Controla o comportamento de ataque do boss focado em defesa
  /// </summary>
  public class BossEnemyDefenderAttackController : BossEnemyAttackController {

    #region Propriedades

    public override float specialShootTimer => 
      base.specialShootTimer.randomInRange(1.5f)
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Dispara dois tiros na direção do jogador.
    /// </summary>
    public override IEnumerator normalAttack () {
      while (true) {
        yield return new WaitForSeconds(shootTimer);
        for (byte i = 0; i < 2; i++) {
          shoot(weapons[i], this.getPlayerDirection(weapons[i]));
        }
      }
    }

    /// <summary>
    /// Instancia e coloca os tiros como filhos do objeto que tem esse script
    /// para que eles se movam junto com a nave.
    /// </summary>
    public override IEnumerator specialAttack () {
      while (true) {
        yield return new WaitForSeconds(specialShootTimer);
        for (byte i = 2; i < 4; i++) {
          instantiateBullet(weapons[i], setAsChild: true);
        }
      }
    }

    #endregion

  }
}
