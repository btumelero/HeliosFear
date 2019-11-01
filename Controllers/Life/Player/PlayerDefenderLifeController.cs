public class PlayerDefenderLifeController : PlayerLifeController {

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    _hp = 12;
    baseShield = 24;
    base.Start();
    regenerationTimer.baseTime = 2;
  }

}
