using Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common;
using Assets.Source.App.Utils.Enums;

using UnityEngine;

/// <summary>
/// Contém classes responsáveis por impedir que objetos saiam da tela
/// </summary>
namespace Assets.Source.App.Utils.ScreenLimits {

  /// <summary>
  /// Classe responsável por impedir que naves saiam da tela
  /// </summary>
  public class SpaceshipBouncer : MonoBehaviour {

    #region Métodos da Unity

    /// <summary>
    /// Se for uma nave inimiga, muda a direção caso atinjam as laterais da tela
    /// ou as destrói caso sejam kamikazes
    /// </summary>
    /// 
    /// <param name="other">
    /// o objeto que atingiu o objeto que tem esse script
    /// </param>
    public void OnTriggerEnter (Collider other) {
      if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy")) {
        if (other.transform.root.TryGetComponent(out CommonEnemyMovementController spaceship)) {
          bounce(spaceship);
        } else {//kamikaze
          Destroy(other.transform.root.gameObject);
        }
      }
    }

    #endregion

    #region Meus métodos

    /// <summary>
    /// Inverte a direção em que a nave está indo
    /// </summary>
    /// 
    /// <param name="spaceship">
    /// O controlador de movimento da nave que terá a direção invertida
    /// </param>
    private void bounce (CommonEnemyMovementController spaceship) {
      if (spaceship.moving.Value == (int) Movements.Rightward) {
        spaceship.moving.Value = (int) Movements.Leftward;
      } else
      if (spaceship.moving.Value == (int) Movements.Leftward) {
        spaceship.moving.Value = (int) Movements.Rightward;
      }
    }

    #endregion

  }

}