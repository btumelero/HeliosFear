using UnityEngine;

public class NormalBulletController : BulletController {

  public override void hitShield (LifeController lifeController) {
    base.hitShield(lifeController);
    showEffect();
  }

  public override void hitSpaceship (LifeController lifeController) {
    base.hitSpaceship(lifeController);
    showEffect();
  }

  protected override void showEffect () {
    base.showEffect();
    Destroy(gameObject);
  }
}
