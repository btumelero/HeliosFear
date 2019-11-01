using UnityEngine;

public class ObjectBouncer : MonoBehaviour {

  #region Métodos da Unity

  /*
   * Muda a direção das naves inimigas caso atinjam as laterais da tela
   */
  public void OnTriggerEnter (Collider other) {
    if (other.gameObject.tag.Equals("Enemy")) {
      bounce(other.GetComponentInParent<EnemyMovementController>());
    }
  }

  #endregion

  #region Meus métodos

  /*
   * Inverte a direção em que a nave está indo
   */
  private void bounce (EnemyMovementController spaceship) {
    if (spaceship.moving == EnemyMovementController.movementType.RIGHTWARD) {
      spaceship.moving = EnemyMovementController.movementType.LEFTWARD;
    } else if (spaceship.moving == EnemyMovementController.movementType.LEFTWARD) {
      spaceship.moving = EnemyMovementController.movementType.RIGHTWARD;
    }
  }

  #endregion

}
