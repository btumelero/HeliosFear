using Assets.Source.App.Controllers.Spaceship.Attack;
using Assets.Source.App.Controllers.Spaceship.Life;
using Assets.Source.App.Controllers.Spaceship.Movement;
using Assets.Source.App.Utils.Enums;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Energy {

  /// <summary>
  /// Controla o comportamento da energia da nave
  /// </summary>
  public abstract class EnergyController : MonoBehaviour {

    #region Campos

    public Multipliers multipliers;

    /// <summary>
    /// Referência do controlador de ataque
    /// </summary>
    [HideInInspector] public AttackController attackController;

    /// <summary>
    /// Referência do controlador de vida
    /// </summary>
    [HideInInspector] public LifeController lifeController;

    /// <summary>
    /// Referência do controlador de movimento
    /// </summary>
    [HideInInspector] public MovementController movementController;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Atualiza o valor atual de escudo
    /// </summary>
    public void updateSpaceshipShieldStatus () {
      lifeController.maxShield.Value = 
        lifeController.baseShield * multipliers[Sliders.Shield, raw: false]
      ;
      lifeController.actualRegeneration = 
        lifeController.baseRegeneration * multipliers[Sliders.Shield, raw: false]
      ;
    }

    /// <summary>
    /// Atualiza o valor atual de velocidade
    /// </summary>
    public void updateSpaceshipSpeedStatus () {
      movementController.actualSpeed = 
        movementController.baseSpeed * multipliers[Sliders.Speed, raw: false]
      ;
    }

    /// <summary>
    /// Atualiza o valor atual de dano
    /// </summary>
    public void updateSpaceshipWeaponStatus () {
      attackController.actualShootPower = 
        attackController.baseShootPower * multipliers[Sliders.Weapon, raw: false]
      ;
    }

    public virtual void updateSpaceshipStatus () {
      updateSpaceshipShieldStatus();
      updateSpaceshipSpeedStatus();
      updateSpaceshipWeaponStatus();
    }

    #endregion

  }
}
