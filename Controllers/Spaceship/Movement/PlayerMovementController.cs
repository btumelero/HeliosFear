using UnityEngine;

public class PlayerMovementController : MovementController {

  #region Variáveis

  public ScreenLimits screenLimits;

  #endregion

  #region Métodos da Unity

  /*
   * Move a nave do jogador conforme os botões que ele está apertando e impede que ele saia da tela
   */
  protected override void FixedUpdate () {
    transform.Translate(
      Input.GetAxis("Horizontal") * actualSpeed * (Time.fixedDeltaTime),
      Input.GetAxis("Vertical") * actualSpeed * (Time.fixedDeltaTime),
      0
    );
    if (screenLimits.yEdgeReached(transform.position.y) || screenLimits.xEdgeReached(transform.position.x)) {
      limitMovement();
    }
  }

  #endregion

  #region Meus métodos

  /*
   * Impede que o jogador saia da tela
   */
  private void limitMovement () {
    transform.position = new Vector3(
      Mathf.Clamp(transform.position.x, screenLimits.minimumX, screenLimits.maximumX),
      Mathf.Clamp(transform.position.y, screenLimits.minimumY, screenLimits.maximumY),
      0f
    );
  }

  #endregion

}
