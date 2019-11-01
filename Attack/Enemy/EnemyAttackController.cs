public abstract class EnemyAttackController : AttackController {

  /*
   * Update is called once per frame
   * 
   * Atira quando o timer esgota e reinicia o timer
   */ 
  protected override void Update () {
    if (shootTimer.timeIsUp()) {
      shootAppropriateNumberOfShoots();
      shootTimer.restart();
    }
  }

}
