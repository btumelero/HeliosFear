using Assets.Source.App.Controllers.Spaceship.Life;
using Assets.Source.App.Utils.Extensions;

using UnityEngine;

namespace Assets.Source.App.Controllers.Bullets {

  /// <summary>
  /// Classe responsável por gerenciar tiros normais
  /// </summary>
  public class NormalBulletController : BulletController {

    #region Meus Métodos

    /// <summary>
    /// Dá dano no escudo e exibe um efeito
    /// </summary>
    /// 
    /// <param name="lifeController">
    /// O controlador de vida da nave
    /// </param>
    public override void hit (LifeController lifeController) {
      base.hit(lifeController);
      showEffect();
      Destroy(gameObject);
    }

    /// <summary>
    /// Faz a bala se mover.
    /// </summary>
    /// 
    /// <param name="shootVelocity">
    /// A velocidade do tiro.
    /// </param>
    /// 
    /// <param name="direction">
    /// A direção em que o tiro deve ser disparado.
    /// </param>
    public void moveBullet (float shootVelocity, Vector3 direction) {
      bulletBody.setVelocity(direction, shootVelocity);
    }

    /// <summary>
    /// Rotaciona o tiro na direção do movimento dele.
    /// </summary>
    public override void rotateBullet (Vector3 direction) {
      base.rotateBullet(direction);
      transform.rotation = Quaternion.Euler(
        transform.rotation.eulerAngles.x + 90,
        transform.rotation.eulerAngles.y,
        transform.rotation.eulerAngles.z
      );
    }

    #endregion

  }
}
