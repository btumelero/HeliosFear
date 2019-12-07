using Delegates;

using Interfaces.Movements;

using UnityEngine;

public class PlayerMovementController : MovementController, IMovement {

  #region Variáveis

  public ScreenLimits screenLimits;
  public MovementType move;
  public Vector3 _startingPosition;

  #endregion

  #region Getters e Setters

  public Vector3 startingPosition { 
    get => _startingPosition;
  }

  public GameObject spaceship {
    get => gameObject;
  }

  #endregion

  #region Métodos da Unity

  /*
   * Move a nave do jogador conforme os botões que ele está apertando e impede que ele saia da tela
   */
  protected override void FixedUpdate () {
    if (move != null) {
      move();
    }
  }

  #endregion

  #region Meus métodos

  public void normalMovement () {
    transform.Translate(
      Input.GetAxis(Enums.Input.Horizontal.ToString()) * _actualSpeed * (Time.fixedDeltaTime),
      Input.GetAxis(Enums.Input.Vertical.ToString()) * _actualSpeed * (Time.fixedDeltaTime),
      0
    );
    if (screenLimits.yEdgeReached(transform.position.y) || screenLimits.xEdgeReached(transform.position.x)) {
      limitMovement();
    }
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
