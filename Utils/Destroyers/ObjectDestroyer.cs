using UnityEngine;

/// <summary>
/// Uma das classes responsáveis pela destruição de objetos
/// </summary>
public class ObjectDestroyer : MonoBehaviour {

  #region Métodos da Unity

  /// <summary>
  /// Destrói objetos que saíram da tela e atigiram 
  /// </summary>
  /// <param name="other">
  /// O objeto que atingiu o objeto que tem esse script
  /// </param>
  public void OnTriggerEnter (Collider other) {
    Destroy(other.transform.root.gameObject);
  }

  #endregion

}
