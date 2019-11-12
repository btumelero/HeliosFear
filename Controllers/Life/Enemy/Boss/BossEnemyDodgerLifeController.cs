public class BossEnemyDodgerLifeController : EnemyLifeController {

  /*
   * Start is called before the first frame update
   * Inicializações apenas
   */
  protected override void Start () {
    base.Start();
    _hp = 20;
    baseShield = 40;
    _shield = baseShield;
    maxShield = baseShield;
    regenerationTimer.baseTime = 5;
  }

}
