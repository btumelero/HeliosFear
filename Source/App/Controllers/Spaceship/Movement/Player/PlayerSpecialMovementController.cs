using System.Collections;

using Assets.Source.App.Data.Utils;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Player {

  /// <summary>
  /// Classe responsável por gerenciar os movimentos do jogador durante a missão contra o boss de defesa
  /// </summary>
  public class PlayerSpecialMovementController : PlayerNormalMovementController, ISpecialMovement {

    #region Propriedades

    /// <summary>
    /// A posição especial do jogador na tela
    /// </summary>
    public Vector3? specialPosition { get; set; } 
      
    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// Permite que o jogador possa girar a nave enquanto está parado no centro da tela
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar a rotina specialMovement
    /// </returns>
    public IEnumerator specialMovement () {
      while (true) {
        yield return new WaitForFixedUpdate();
        transform.Rotate(
          xAngle: 0,
          yAngle: 0,
          zAngle: -Input.GetAxis(Inputs.Horizontal.ToString()) * (actualSpeed * 3) * Time.fixedDeltaTime
        );
      }
    }

    /// <summary>
    /// Controla a mudança entre os dois tipos de movimentação
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar a rotina switchMovements
    /// </returns>
    public IEnumerator switchMovements (IEnumerator previousCoroutine) {
      string
        previousMovement = previousCoroutine.ToString(),
        normalMovement = this.normalMovement().ToString()
      ;
      while (true) {
        yield return new WaitForFixedUpdate();
        if (previousMovement.Equals(normalMovement)) {
          switchToSpecialMovement();
        } else {
          switchToNormalMovement();
        }
      }
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Alterna para a forma de movimentação especial
    /// </summary>
    private void switchToSpecialMovement () {
      this.moveTowards(Position.screenCenter, actualSpeed);
      if (this.positionIs(Position.screenCenter)) {
        movementCoroutine.play(specialMovement());
      }
    }

    /// <summary>
    /// Alterna para a forma de movimentação normal
    /// </summary>
    private void switchToNormalMovement () {
      this.rotateTowards(Rotation.zero, actualSpeed * 3);
      this.moveTowards(startingPosition, actualSpeed);
      if (this.positionAndRotationEquals(startingPosition, Rotation.zero)) {
        movementCoroutine.play(normalMovement());
      }
    }


    #endregion

  }
}
