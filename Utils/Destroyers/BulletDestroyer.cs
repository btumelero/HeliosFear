using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

  #region Métodos da Unity
  
  /*
   * Destrói os tiros que atigirem o objeto que tem esse script
   */
  private void OnTriggerEnter (Collider other) {
    if (other.gameObject.tag.Contains("Bullet")) {
      Destroy(other.gameObject);
    }
  }

  #endregion

}
