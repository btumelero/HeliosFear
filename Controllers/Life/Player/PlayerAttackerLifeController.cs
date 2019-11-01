using UnityEngine;

public class PlayerAttackerLifeController : PlayerLifeController {

  /*
   * Start is called before the first frame update
   */
  protected override void Start () {
    _hp = 6;
    baseShield = 12;
    base.Start();
    regenerationTimer.baseTime = 5;
  }

}
