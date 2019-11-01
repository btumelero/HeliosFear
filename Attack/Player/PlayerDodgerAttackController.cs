public class PlayerDodgerAttackController : PlayerAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = 0.25f;
    baseShootPower = 1.5f;
  }

  #endregion
}
