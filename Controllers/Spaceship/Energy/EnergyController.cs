using UnityEngine;

/// <summary>
/// Controla o comportamento da energia da nave
/// </summary>
public abstract class EnergyController : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// Valor pelo qual será multiplicado o valor base de escudo
  /// </summary>
  public float _shieldMultiplier;

  /// <summary>
  /// Valor pelo qual será multiplicado o valor base de velocidade
  /// </summary>
  public float _speedMultiplier;

  /// <summary>
  /// Valor pelo qual será multiplicado o valor base de dano
  /// </summary>
  public float _weaponMultiplier;

  /// <summary>
  /// Referência do controlador de ataque
  /// </summary>
  public AttackController attackController { get; set; }

  /// <summary>
  /// Referência do controlador de vida
  /// </summary>
  public LifeController lifeController { get; set; }

  /// <summary>
  /// Referência do controlador de movimento
  /// </summary>
  public MovementController movementController { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Valor pelo qual será multiplicado o valor base de escudo
  /// </summary>
  public abstract float shieldMultiplier { get; set; }

  /// <summary>
  /// Valor pelo qual será multiplicado o valor base de velocidade
  /// </summary>
  public abstract float speedMultiplier { get; set; }

  /// <summary>
  /// Valor pelo qual será multiplicado o valor base de dano
  /// </summary>
  public abstract float weaponMultiplier { get; set; }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Atualiza o valor atual de escudo
  /// </summary>
  protected virtual void updateSpaceshipShieldStatus () {
    lifeController.maxShield = lifeController.baseShield * (_shieldMultiplier / 50);
    lifeController.actualRegeneration = lifeController.baseRegeneration * (_shieldMultiplier / 50);
  }

  /// <summary>
  /// Atualiza o valor atual de velocidade
  /// </summary>
  protected void updateSpaceshipSpeedStatus () {
    movementController._actualSpeed = movementController._baseSpeed * (_speedMultiplier / 50);
  }

  /// <summary>
  /// Atualiza o valor atual de dano
  /// </summary>
  protected void updateSpaceshipWeaponStatus () {
    attackController.actualShootPower = attackController.baseShootPower * (_weaponMultiplier / 50);
  }

  #endregion
}
