using UnityEngine;

public class ObjectBouncer : MonoBehaviour {

  #region Métodos da Unity

  /*
   * Muda a direção das naves inimigas caso atinjam as laterais da tela
   */
  public void OnTriggerEnter (Collider other) {
    if (other.gameObject.tag.Equals(Enums.Tags.Enemy.ToString())) {
      bounce(other.GetComponentInParent<EnemyMovementController>());
    }
  }

  #endregion

  #region Meus métodos

  /*
   * Inverte a direção em que a nave está indo
   */
  private void bounce (EnemyMovementController spaceship) {
    if (spaceship.moving == Enums.Movement.Rightward) {
      spaceship.moving = Enums.Movement.Leftward;
    } else if (spaceship.moving == Enums.Movement.Leftward) {
      spaceship.moving = Enums.Movement.Rightward;
    }
  }

  #endregion

}
