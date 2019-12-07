using UnityEngine;

public class SpaceshipBouncer : MonoBehaviour {

  #region Métodos da Unity

  /**
   * Muda a direção das naves inimigas caso atinjam as laterais da tela
   */
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
  
  /**
   * Inverte a direção em que a nave está indo
   */
  private void bounce (CommonEnemyMovementController spaceship) {
    if (spaceship.moving == Enums.Movement.Rightward) {
      spaceship.moving = Enums.Movement.Leftward;
    } else
    if (spaceship.moving == Enums.Movement.Leftward) {
      spaceship.moving = Enums.Movement.Rightward;
    }
  }

  private bool isKamikaze (CommonEnemyMovementController movementController) {
    return movementController == null;
  }

  #endregion

}
