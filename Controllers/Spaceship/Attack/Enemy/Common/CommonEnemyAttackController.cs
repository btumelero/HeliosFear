using Interfaces;

public class CommonEnemyAttackController : EnemyAttackController, IAttack {

  #region Métodos da Unity

  /**
   * Update is called once per frame
   * 
   * Atira quando o timer esgota e reinicia o timer
   */
  protected override void Update () {
    if (shootTimer.timeIsUp()) {
      normalAttack();
      shootTimer.restart();
    }
  }

  #endregion

  #region Meus Métodos

  public void normalAttack () {
    for (byte i = 0; i < weapons.Length; i++) {
      instantiateRotateAndMoveBullet(weapons[i]);
    }
  }

  #endregion

}
