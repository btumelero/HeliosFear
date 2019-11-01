public class PlayerNormalAttackController : PlayerAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = 0.2f;
    baseShootPower = 2f;
  }

  #endregion

}
