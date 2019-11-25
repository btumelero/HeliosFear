using UnityEngine;

public abstract class AttackController : MonoBehaviour {

  #region Variáveis

  public GameObject bullet;
  public Transform[] shootPositions;
  public Timer shootTimer { get; set; }

  public float actualShootPower;
  public float baseShootPower;
  public float shootVelocity;

  #endregion

  #region Métodos da Unity

  protected abstract void Update ();

  #endregion

  #region Meus Métodos

  protected abstract void shootAppropriateNumberOfShoots ();

  /*
   * Instancia e move o tiro na direção indicada, rotacionando o objeto nessa direcão e inicializando a potência dele
   */
  protected void instantiateAndMoveBullet (Transform spawner, Vector3 direction) {
    if (direction != null && spawner != null) {
      GameObject newbullet = Instantiate(
        bullet,
        new Vector3(spawner.position.x, spawner.position.y, 0),
        Quaternion.Euler(90, 0, 0)
      );
      Rigidbody bulletBody = newbullet.GetComponent<Rigidbody>();
      bulletBody.velocity = direction * shootVelocity;
      newbullet.transform.LookAt(bulletBody.velocity + spawner.position);
      newbullet.GetComponent<BulletController>().shootPower = baseShootPower;
    }
  }


  #endregion

}
