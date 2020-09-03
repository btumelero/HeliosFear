using System.Linq;

using Assets.Source.App.Controllers.Spaceship.Attack.Enemy.Boss;
using Assets.Source.App.Controllers.Spaceship.Life.Enemy.Boss;
using Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Boss;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Data.Utils;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.Experimental;

using UnityEngine;

/// <summary>
/// Contém as classes responsáveis por construir as naves do jogo
/// </summary>
namespace Assets.Source.App.Builders.Spaceship {

  /// <summary>
  /// Classe responsável por construir os bosses do jogo
  /// </summary>
  public class BossBuilder : EnemyBuilder {

    #region Propriedades

    /// <summary>
    /// Retorna o controlador de ataque do boss
    /// </summary>
    protected new BossEnemyAttackController attackController =>
      (BossEnemyAttackController) _attackController
    ;

    /// <summary>
    /// Retorna o controlador de vida do boss
    /// </summary>
    protected new BossEnemyLifeController lifeController =>
      (BossEnemyLifeController) _lifeController
    ;

    /// <summary>
    /// Retorna o controlador de movimento do boss
    /// </summary>
    protected new BossEnemyMovementController movementController =>
      (BossEnemyMovementController) _movementController
    ;

    #endregion

    #region Meus Métodos

    public override void onBuild (AttackData attackData) {
      base.onBuild(attackData);
      attackController.specialAttackCoroutine =
        attackController.gameObject.AddComponent<CoroutineController>()
      ;
    }

    /// <summary>
    /// Inicializa o controlador de vida do boss
    /// </summary>
    /// 
    /// <param name="lifeData">
    /// Os dados de vida do boss
    /// </param>
    public override void onBuild (LifeData lifeData) {
      base.onBuild(lifeData);
      lifeController.spaceshipBodyCollider = _lifeController.GetComponentInChildren<BoxCollider>();
      lifeController.vulnerable = new FieldWithAction<bool>() {
        Value = true,
        onValueChange = lifeController.onVulnerableValueChanged
      };
    }

    /// <summary>
    /// Inicializa o controlador de movimento do boss
    /// </summary>
    /// 
    /// <param name="movementData">
    /// Os dados de movimento do boss
    /// </param>
    public override void onBuild (MovementData movementData) {
      base.onBuild(movementData);
      movementController.specialPosition = movementData.specialPosition;
      if (_movementController is BossEnemyDefenderMovementController bossEnemyDefenderMC) {
        bossEnemyDefenderMC.transform.position = movementController.specialPosition.Value;
      } else
      if (_movementController is BossEnemyDodgerMovementController bossEnemyDodgerMC) {
        bossEnemyDodgerMC.specialRotation = Rotation.facingScreen;
        bossEnemyDodgerMC.orbit = GameObject.Instantiate(bossEnemyDodgerMC.orbit);
        bossEnemyDodgerMC.movementZone = bossEnemyDodgerMC.orbit.GetComponentInChildren<BoxCollider>();
        bossEnemyDodgerMC.spaceshipParts =
          bossEnemyDodgerMC.GetComponentsInChildren<Renderer>()
            .ToList()
            .FindAll(renderer => renderer.material.HasProperty("_Color"))
        ;
      }
    }

    #endregion

  }

}