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
    move();
  }

  #endregion

  #region Meus métodos

  public delegate void move();

  public void normalMovement () {
    transform.Translate(
      Input.GetAxis(Enums.Input.Horizontal.ToString()) * actualSpeed * (Time.fixedDeltaTime),
      Input.GetAxis(Enums.Input.Vertical.ToString()) * actualSpeed * (Time.fixedDeltaTime),
      0
    );
    if (screenLimits.yEdgeReached(transform.position.y) || screenLimits.xEdgeReached(transform.position.x)) {
      limitMovement();
    }
  }

  public void specialMovement () {
    transform.Rotate(//checar se é x ou y
      Input.GetAxis(Enums.Input.Horizontal.ToString()) * actualSpeed * Time.fixedDeltaTime,
      0,
      0
    );
  } 

  public void toScreenCenter () {
    transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, actualSpeed * Time.fixedDeltaTime)
  }

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
