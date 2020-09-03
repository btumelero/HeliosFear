using Extensions;

using UnityEngine;

/// <summary>
/// Classe responsável pelo controle dos kamikazes
/// </summary>
public class KamikazeController : MonoBehaviour {

  #region Variáveis

  private static readonly float velocity = 450f;
  private static Vector3 screenCenter = Vector3.zero;

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Faz o kamikaze se mover na direção do centro da tela
  /// </summary>
  private void Start () {
    Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
    rigidbody.setVelocity(
      (screenCenter - transform.position).normalized,
      velocity * Time.fixedDeltaTime);
    transform.root.LookAt(rigidbody.velocity + transform.position);
  }

  /// <summary>
  /// Causa dano no jogador caso tenha acertado ele e destrói o kamikaze caso ele tenha acertado ou sido acertado por algo
  /// </summary>
  /// 
  /// <param name="other">
  /// O objeto que colidiu com esse objeto
  /// </param>
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
