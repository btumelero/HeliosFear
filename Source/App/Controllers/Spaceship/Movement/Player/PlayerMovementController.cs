using Assets.Source.App.Data.Mission;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.ScreenLimits;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Player {

  public abstract class PlayerMovementController : MovementController {

    #region Campos

    /// <summary>
    /// A área da tela em que o jogador pode se mover
    /// </summary>
    public ScreenLimits screenLimits;

    #endregion

    #region Propriedades

    /// <summary>
    /// A posição inicial do jogador na tela
    /// </summary>
    public Vector3 startingPosition =>
      SpaceshipData.values[gameObject.tag].movementData.startingPosition
    ;

    /// <summary>
    /// A velocidade base do objeto
    /// </summary>
    public override float baseSpeed => 
      base.baseSpeed * (0.75f + (PlayerData.engineStrength / 4))
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Impede que o jogador saia da tela
    /// </summary>
    protected void limitMovement () {
      transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, screenLimits.minimumX, screenLimits.maximumX),
        Mathf.Clamp(transform.position.y, screenLimits.minimumY, screenLimits.maximumY),
        0f
      );
    }

    #endregion

  }
}
