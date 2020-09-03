using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Collision.Bullets
{
  /// <summary>
  /// Classe responsável por controlar colisões com tiros especiais
  /// </summary>
  public class BeamCollisionController : BulletCollisionController {

    #region Variáveis

    /// <summary>
    /// O dano original desse tiro especial
    /// </summary>
    private float originalShootPower;

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Dá um primeiro dano maior e diminui o dano do tiro para caso a nave continue sendo acertada
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    protected override void OnTriggerEnter (Collider collider) {
      base.OnTriggerEnter(collider);
      originalShootPower = bulletController.shootPower;
      bulletController.shootPower = originalShootPower * (Time.deltaTime * 2);
    }

    /// <summary>
    /// Dá um dano menor ao longo do tempo enquanto a nave inimiga continuar sendo atingida 
    /// por esse tiro especial
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    private void OnTriggerStay (Collider collider) {
      onCollision(collider);
    }

    /// <summary>
    /// Reseta o dano do tiro especial quando a nave inimiga deixar de ser atingida pelo tiro
    /// </summary>
    /// 
    /// <param name="collider">
    /// O objeto que colidiu com o objeto que tem esse script
    /// </param>
    private void OnTriggerExit (Collider collider) {
      bulletController.shootPower = originalShootPower;
    }

    #endregion

  }
}
