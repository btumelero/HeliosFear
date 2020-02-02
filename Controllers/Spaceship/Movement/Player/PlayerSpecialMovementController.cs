using Extensions;

using Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar os movimentos do jogador durante a missão contra o boss de defesa
/// </summary>
public class PlayerSpecialMovementController : PlayerMovementController, ISpecialMovement {

  #region Getters e Setters

  /// <summary>
  /// A posição especial do jogador na tela
  /// </summary>
  public Vector3 specialPosition { get; set; }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// O jogador pode girar a nave enquanto está parado no centro da tela
  /// </summary>
  public void specialMovement () {
    transform.Rotate(
      0,
      0,
      -Input.GetAxis(Enums.Input.Horizontal.ToString()) * (_actualSpeed * 3) * Time.fixedDeltaTime
    );
  }

  /// <summary>
  /// Alterna para a forma de movimentação especial
  /// </summary>
  public void switchToSpecialMovement () {
    gameObject.moveTowards(Vector3.zero, _actualSpeed);
    if (gameObject.isAt(Vector3.zero)) {
      move = specialMovement;
    }
  }

  /// <summary>
  /// Alterna para a forma de movimentação normal
  /// </summary>
  public void switchToNormalMovement () {
    if (gameObject.rotationIsZero() == false) {
      gameObject.rotateTowards(Quaternion.Euler(0, 0, 0), _actualSpeed * 3);
      gameObject.moveTowards(_startingPosition, _actualSpeed);
    } else {
      move = normalMovement;
    }
  }

  #endregion

}
