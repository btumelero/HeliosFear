using Assets.Source.App.Controllers.Spaceship.Life;
using Assets.Source.App.Data.Utils;
using Assets.Source.App.Utils.Extensions;
using UnityEngine;

namespace Assets.Source.App.Controllers.Other{

  /// <summary>
  /// Classe responsável pelo controle dos kamikazes
  /// </summary>
  public class KamikazeController : MonoBehaviour {

    #region Campos

    private static readonly float velocity = 450f;

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Faz o kamikaze se mover na direção do centro da tela
    /// </summary>
    private void Start () {
      Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
      rigidbody.setVelocity(
        (Position.screenCenter - transform.position).normalized,
        velocity * Time.fixedDeltaTime
      );
      transform.root.LookAt(transform.position + rigidbody.velocity);
    }

    /// <summary>
    /// Causa dano no jogador caso tenha acertado ele e destrói o kamikaze caso ele tenha acertado ou sido acertado por algo
    /// </summary>
    /// 
    /// <param name="other">
    /// O objeto que colidiu com esse objeto
    /// </param>
    private void OnTriggerEnter (Collider other) {
      bool hitPlayer = LayerMask.LayerToName(other.gameObject.layer).Equals("Player");
      if (hitPlayer) {
        other.transform.root.GetComponent<LifeController>().shield.Value--;
      }
      Destroy(gameObject);
    }

    #endregion

  }
}
