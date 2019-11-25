using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

  #region Métodos da Unity
  
  /*
   * Destrói os tiros que atigirem o objeto que tem esse script
   */
  private void OnTriggerEnter (Collider other) {
    if (other.gameObject.tag.Contains(Enums.Tags.Bullet.ToString())) {
      Destroy(other.gameObject);
    }
  }

  #endregion

}
