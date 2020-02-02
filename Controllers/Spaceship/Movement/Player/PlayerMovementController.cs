using Delegates;

using Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar os movimentos da nave do jogador
/// </summary>
public class PlayerMovementController : MovementController, IMovement {

  #region Variáveis

  /// <summary>
  /// A área da tela em que o jogador pode se mover
  /// </summary>
  public ScreenLimits screenLimits;

  /// <summary>
  /// A forma como o jogador pode se mover no momento.
  /// Um Delegate é usado para dar mais flexibilidade para a manipulação
  /// </summary>
  public MovementType move;

  /// <summary>
  /// A posição inicial do jogador na tela
  /// </summary>
  public Vector3 _startingPosition;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// A posição inicial do jogador na tela
  /// </summary>
  public Vector3 startingPosition { 
    get => _startingPosition;
  }

  /// <summary>
  /// A nave do jogador
  /// </summary>
  public GameObject spaceship {
    get => gameObject;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Dependendo do tipó e estágio da missão, pode permitir que o jogador controle sua nave de diferentes formas.
  /// </summary>
  protected override void FixedUpdate () {
    move?.Invoke();
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Move a nave do jogador conforme os botões que ele está apertando e impede que ele saia da tela
  /// </summary>
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

  /// <summary>
  /// Impede que o jogador saia da tela
  /// </summary>
  private void limitMovement () {
    transform.position = new Vector3(
      Mathf.Clamp(transform.position.x, screenLimits.minimumX, screenLimits.maximumX),
      Mathf.Clamp(transform.position.y, screenLimits.minimumY, screenLimits.maximumY),
      0f
    );
  }

  #endregion

}
