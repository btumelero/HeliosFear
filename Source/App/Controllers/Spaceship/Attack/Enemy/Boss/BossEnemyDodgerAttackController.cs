using System.Collections;

using Assets.Source.App.Utils.Extensions;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Attack.Enemy.Boss {

  /// <summary>
  /// Classe responsável por controlar o comportamento de ataque do boss focado em velocidade
  /// </summary>
  public class BossEnemyDodgerAttackController : BossEnemyAttackController {

    #region Propriedades

    public override float specialShootTimer => 
      base.specialShootTimer.randomInRange(0.2f)
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Dispara um tiro para baixo
    /// </summary>
    public override IEnumerator normalAttack () {
      while (true) {
        yield return new WaitForSeconds(shootTimer);
        instantiateBullet(weapons[0], setAsChild: true);
      }
    }

    /// <summary>
    /// Dispara um tiro para cima e outro para baixo
    /// </summary>
    public override IEnumerator specialAttack () {
      while (true) {
        yield return new WaitForSeconds(specialShootTimer);
        instantiateBullet(weapons[1], setAsChild: false);
        instantiateBullet(weapons[2], setAsChild: false);
      }
    }

    #endregion

  }
}
