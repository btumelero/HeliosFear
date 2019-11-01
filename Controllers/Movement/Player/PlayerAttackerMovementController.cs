public class PlayerAttackerMovementController : PlayerMovementController {

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade base do jogador
   */
  protected override void Start () {
    baseSpeed = 25;
    screenLimits.minimumX = -22;
    screenLimits.maximumX = 22;
    screenLimits.minimumY = -15;
    screenLimits.maximumY = 17;
  }

}
