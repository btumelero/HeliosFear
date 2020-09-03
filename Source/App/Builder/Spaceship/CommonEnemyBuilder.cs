using Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.Enums;
using Assets.Source.Experimental;

using UnityEngine;

/// <summary>
/// Contém as classes responsáveis por construir as naves do jogo
/// </summary>
namespace Assets.Source.App.Builders.Spaceship {

  /// <summary>
  /// Classe responsável por construir os inimigos comuns do jogo
  /// </summary>
  public class CommonEnemyBuilder : EnemyBuilder {

    #region Propriedades

    /// <summary>
    /// O controlador de movimento do inimigo comum
    /// </summary>
    protected new CommonEnemyMovementController movementController =>
      (CommonEnemyMovementController) _movementController
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Inicializa o controlador de movimento do inimigo comum
    /// </summary>
    /// 
    /// <param name="movementData">
    /// Os dados de movimento do inimigo comum
    /// </param>
    public override void onBuild (MovementData movementData) {
      if (movementController.spaceshipBody == null) {
        movementController.moving = new FieldWithAction<int>() {
          onValueChange = movementController.onMovingValueChanged
        };
        movementController.spaceshipBody = objectToBuild.GetComponent<Rigidbody>();
      }
      base.onBuild(movementData);
      movementController.movementCoroutine.play(movementController.normalMovement());
    }

    /// <summary>
    /// Inicializa campos que dependem uns dos outros
    /// </summary>
    /// 
    /// <param name="spaceshipData">
    /// Os dados do inimigo comum
    /// </param>
    public override void onBuild (SpaceshipData spaceshipData) {
      base.onBuild(spaceshipData);
      movementController.switchMovementDirection();
      attackController.normalAttackCoroutine.play(attackController.normalAttack());
    }

    #endregion

  }
}