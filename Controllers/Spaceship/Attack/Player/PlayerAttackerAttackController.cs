public class PlayerAttackerAttackController : PlayerAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = 0.15f;
    baseShootPower = 3f;
  }

  #endregion
}
