using UnityEngine;

public class BulletCollisionController : CollisionController {

  #region Variáveis

  public BulletController bulletController { get; set; }

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    bulletController = gameObject.GetComponentInParent<BulletController>();
  }

  #endregion

  #region Meus Métodos

  protected override bool isCollision () {
    return compareCollidersTags(Enums.Tags.FriendlyBullet, Enums.Tags.EnemyBullet);
  }

  protected override void onCollision () {
    if (tagList[0].Contains("Shield")) {
      bulletController.hitShield(colliderLifeController);
    } else {
      if (colliderLifeController != null) {
        if (colliderLifeController.shield <= 0) {
          bulletController.hitSpaceship(colliderLifeController);
        }
      }
    }
  }

  #endregion

}
