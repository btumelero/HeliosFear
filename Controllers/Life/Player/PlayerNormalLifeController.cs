public class PlayerNormalLifeController : PlayerLifeController {

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    _hp = 8;
    baseShield = 16;
    base.Start();
    regenerationTimer.baseTime = 4;
  }

}
