using Extensions;
using UnityEngine;

public class KamikazeController : MonoBehaviour {

  #region Variáveis

  private static readonly float velocity = 450f;
  private static Vector3 screenCenter = Vector3.zero;

  #endregion

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   * 
   */
  private void Start () {
    Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
    rigidbody.setVelocity(
      (screenCenter - transform.position).normalized,
      velocity * Time.fixedDeltaTime);
    rigidbody.fixRotation();
  }

  private void OnTriggerEnter (Collider other) {
    bool hitPlayer = other.tag.Contains(Enums.Tags.Player.ToString());
    if (hitPlayer) {
      other.transform.root.GetComponent<LifeController>().shield--;
    }
    if (hitPlayer || other.tag.Equals(Enums.Tags.FriendlyBullet.ToString())) {
      Destroy(gameObject);
    }
  }

  #endregion

}
