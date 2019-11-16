public class BossEnemyAttackerLifeController : EnemyLifeController {

  /*
   * Start is called before the first frame update
   * Inicializações apenas
   */
  protected override void Start () {
    base.Start();
    _hp = 30;
    baseShield = 60;
    _shield = baseShield;
    maxShield = baseShield;
    regenerationTimer.baseTime = 5;
  }

}
