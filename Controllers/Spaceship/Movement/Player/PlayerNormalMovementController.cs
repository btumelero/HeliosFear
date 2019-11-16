public class PlayerNormalMovementController : PlayerMovementController {

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade base do jogador
   */
  protected override void Start () {
    baseSpeed = 30;
    screenLimits.minimumX = -23;
    screenLimits.maximumX = 23;
    screenLimits.minimumY = -16;
    screenLimits.maximumY = 17;
  }

}