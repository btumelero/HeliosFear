public class CommonEnemyDefenderLifeController : EnemyLifeController {

  /*
   * Start is called before the first frame update
   * Inicializações apenas
   */
  protected override void Start () {
    base.Start();
    _hp = 6;
    baseShield = 12;
    _shield = baseShield;
    maxShield = baseShield;
    regenerationTimer.baseTime = 5;
  }

}
