public class BossEnemyLifeController : EnemyLifeController {

  #region Meus Métodos

  protected override void Update () {
    base.Update();
    if (dead) {
      Destroy(gameObject);
    }
  }

  #endregion

}
