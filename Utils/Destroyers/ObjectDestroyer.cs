using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

  #region Métodos da Unity

  /*
   * Destrói objetos que saíram da tela e atigiram o objeto que tem esse script
   */
  public void OnTriggerEnter (Collider other) {
    Destroy(other.transform.root.gameObject);
  }

  #endregion

}
