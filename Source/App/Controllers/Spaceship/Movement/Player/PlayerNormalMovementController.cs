using System.Collections;

using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Player {

  /// <summary>
  /// Classe responsável por gerenciar os movimentos da nave do jogador
  /// </summary>
  public class PlayerNormalMovementController : PlayerMovementController, IMovement {

    #region Meus métodos

    /// <summary>
    /// Move a nave do jogador conforme os botões que ele está apertando e impede que ele saia da tela
    /// </summary>
    public override IEnumerator normalMovement () {
      while (true) {
        yield return new WaitForFixedUpdate();
        transform.Translate(
          Input.GetAxis(Inputs.Horizontal.ToString()) * actualSpeed * (Time.fixedDeltaTime),
          Input.GetAxis(Inputs.Vertical.ToString()) * actualSpeed * (Time.fixedDeltaTime),
          0
        );
        if (screenLimits.yEdgeReached() || screenLimits.xEdgeReached()) {
          limitMovement();
        }
      }
    }

    #endregion

  }
}
