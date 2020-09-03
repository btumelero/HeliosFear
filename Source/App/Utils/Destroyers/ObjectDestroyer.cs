using UnityEngine;

/// <summary>
/// Contém uma série de elementos que podem ser úteis em diferentes cenários
/// </summary>
namespace Assets.Source.App.Utils.Destroyers {

  /// <summary>
  /// Uma das classes responsáveis pela destruição de objetos
  /// </summary>
  public class ObjectDestroyer : MonoBehaviour {

    #region Métodos da Unity

    /// <summary>
    /// Destrói objetos que saíram da tela e atigiram o gameobject que tem esse script
    /// </summary>
    /// 
    /// <param name="other">
    /// O objeto que atingiu o objeto que tem esse script
    /// </param>
    public void OnTriggerEnter (Collider other) {
      Destroy(other.transform.root.gameObject);
    }

    #endregion

  }

}