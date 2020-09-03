using System.Collections;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Attack.Enemy.Common {

  /// <summary>
  /// Classe responsável por controlar o comportamento de ataque dos inimigos comuns
  /// </summary>
  public class CommonEnemyAttackController : EnemyAttackController {

    #region Meus Métodos

    /// <summary>
    /// Dispara um tiro de cada arma, faz ele se mover e rotaciona na direção do movimento
    /// </summary>
    public override IEnumerator normalAttack () {
      while (true) {
        for (byte i = 0; i < weapons.Length; i++) {
          shoot(weapons[i]);
        }
        yield return new WaitForSeconds(shootTimer);
      }
    }

    #endregion

  }

}
