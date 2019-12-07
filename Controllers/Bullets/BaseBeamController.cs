public class BaseBeamController : SpecialBulletController {

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   */
  protected override void Start () {
    base.Start();
    autoDestroyTimer.baseTime = 1;
  }

  #endregion

}
