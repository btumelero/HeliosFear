using UnityEngine;

/// <summary>
/// Contém uma série de elementos que podem ser úteis em diferentes cenários
/// </summary>
namespace Assets.Source.App.Utils.Destroyers {

  /// <summary>
  /// Uma das classes responsáveis pela destruição de objetos
  /// </summary>
  public class BulletDestroyer : MonoBehaviour {

    #region Métodos da Unity

    /// <summary>
    /// Destrói os tiros que atigirem o objeto que tem esse script
    /// </summary>
    /// <param name="other">
    /// O tiro que está colidindo com o objeto que tem esse script
    /// </param>
    private void OnTriggerEnter (Collider other) {
      if (LayerMask.LayerToName(other.gameObject.layer).Contains("Bullet")) {
        Destroy(other.transform.root.gameObject);
      }
    }

    #endregion

  }

}
