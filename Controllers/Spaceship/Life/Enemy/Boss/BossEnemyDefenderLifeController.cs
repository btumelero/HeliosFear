public class BossEnemyDefenderLifeController : EnemyLifeController {

  /*
   * Start is called before the first frame update
   * Inicializações apenas
   */
  protected override void Start () {
    base.Start();
    _hp = 60;
    baseShield = 120;
    _shield = baseShield;
    maxShield = baseShield;
    regenerationTimer.baseTime = 5;
  }

}
