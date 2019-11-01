public class PlayerDefenderAttackController : PlayerAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = 0.3f;
    baseShootPower = 1f;
  }

  #endregion
}
