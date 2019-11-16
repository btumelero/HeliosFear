public class CommonEnemyAttackerLifeController : EnemyLifeController {

  /*
   * Start is called before the first frame update
   * Inicializações apenas
   */
  protected override void Start () {
    base.Start();
    _hp = 3;
    baseShield = 6;
    _shield = baseShield;
    maxShield = baseShield;
    regenerationTimer.baseTime = 5;
  }

}
