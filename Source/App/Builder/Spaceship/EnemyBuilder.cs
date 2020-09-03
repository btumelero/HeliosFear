using Assets.Source.App.Controllers.Spaceship.Attack.Enemy;
using Assets.Source.App.Controllers.Spaceship.Energy;
using Assets.Source.App.Controllers.Spaceship.Life.Enemy;
using Assets.Source.App.Controllers.Spaceship.Movement.Enemy;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;

/// <summary>
/// Contém as classes responsáveis por construir as naves do jogo
/// </summary>
namespace Assets.Source.App.Builders.Spaceship {

  /// <summary>
  /// Classe responsável por construir os inimigos do jogo
  /// </summary>
  public abstract class EnemyBuilder : SpaceshipBuilder {

    #region Propriedades

    /// <summary>
    /// Retorna o controlador de ataque do inimigo
    /// </summary>
    protected new EnemyAttackController attackController =>
      (EnemyAttackController) _attackController
    ;

    /// <summary>
    /// Retorna o controlador de vida do inimigo
    /// </summary>
    protected new EnemyLifeController lifeController =>
      (EnemyLifeController) _lifeController
    ;

    /// <summary>
    /// Retorna o controlador de energia do inimigo
    /// </summary>
    protected new EnemyMovementController movementController =>
      (EnemyMovementController) _movementController
    ;

    /// <summary>
    /// Retorna o controlador de movimento do inimigo
    /// </summary>
    protected new EnemyEnergyController energyController =>
      (EnemyEnergyController) _energyController
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Inicializa o controlador de ataque do inimigo
    /// </summary>
    /// 
    /// <param name="attackData">
    /// Os dados de ataque do inimigo
    /// </param>
    public override void onBuild (AttackData attackData) {
      base.onBuild(attackData);
      attackController.shootTimer = attackData.shootTimer.randomInRange(1.5f);
    }

    /// <summary>
    /// Inicializa o controlador de energia do inimigo
    /// </summary>
    /// 
    /// <param name="energyData">
    /// Os dados de energia do inimigo
    /// </param>
    public override void onBuild (EnergyData energyData) {
      base.onBuild(energyData);
      float
        shield = energyData.shieldMultiplier.randomInRange(20),
        speed = energyData.speedMultiplier.randomInRange(20),
        weapon = energyData.weaponMultiplier.randomInRange(20),
        remainingEnergy = (energyData.totalEnergy - (shield + speed + weapon)) / 3f
      ;
      shield += remainingEnergy;
      speed += remainingEnergy;
      weapon += remainingEnergy;
      if (energyController.multipliers == null) {
        energyController.multipliers = new Multipliers(
          onValueChange: (slider) => energyController.updateSpaceshipStatus(),
          shield,
          speed,
          weapon
        );
      } else {
        energyController.multipliers[Sliders.Shield, raw: true] = shield;
        energyController.multipliers[Sliders.Speed, raw: true] = speed;
        energyController.multipliers[Sliders.Weapon, raw: true] = weapon;
      }
    }

    /// <summary>
    /// Inicializa o controlador de movimento do inimigo
    /// </summary>
    /// 
    /// <param name="movementData">
    /// Os dados de movimento do inimigo
    /// </param>
    public override void onBuild (MovementData movementData) {
      base.onBuild(movementData);
      movementController.movementTimer = movementData.movementTimer.randomInRange(1.5f);
    }

    #endregion

  }
}