public class PlayerDodgerLifeController : PlayerLifeController {

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    _hp = 4;
    baseShield = 8;
    base.Start();
    regenerationTimer.baseTime = 6;
  }

}
