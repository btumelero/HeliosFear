using UnityEngine;

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
    if (other.gameObject.tag.Equals(Enums.Tags.Enemy.ToString())) {
      CommonEnemyMovementController movementController = other.GetComponentInParent<CommonEnemyMovementController>();
      if (isKamikaze(movementController)) {
        Destroy(other.transform.root.gameObject);
      } else {
        bounce(movementController);
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
  /// O controlador de movimento da nave a ter a direção invertida
  /// </param>
  private void bounce (CommonEnemyMovementController spaceship) {
    if (spaceship.moving == Enums.Movement.Rightward) {
      spaceship.moving = Enums.Movement.Leftward;
    } else
    if (spaceship.moving == Enums.Movement.Leftward) {
      spaceship.moving = Enums.Movement.Rightward;
    }
  }

  /// <summary>
  /// Retorna verdadeiro se é um kamikaze
  /// </summary>
  /// 
  /// <param name="movementController">
  /// O controlador de movimento da nave a ser checada
  /// </param>
  /// <returns></returns>
  private bool isKamikaze (CommonEnemyMovementController movementController) {
    return movementController == null;
  }

  #endregion

}
