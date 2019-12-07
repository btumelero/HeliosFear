using UnityEngine;

/**
 * Controla o comportamento da energia da nave
 */
public abstract class EnergyController : MonoBehaviour {

  #region Variáveis

  /**
   * Guardam os valores que estão nos sliders controlados pelo jogador que aparecem na tela
   */
  public float _shieldMultiplier, _speedMultiplier, _weaponMultiplier;

  /**
   * Referência do controlador de ataque
   */
  public AttackController attackController { get; set; }
  
  /**
   * Referência do controlador de vida
   */
  public LifeController lifeController { get; set; }

  /**
   * Referência do controlador de movimento
   */
  public MovementController movementController { get; set; }

  #endregion

  #region Getters e Setters

  /**
   * Valor pelo qual será multiplicado o valor base de escudo
   */
  public abstract float shieldMultiplier { get; set; }
  
  /**
   * Valor pelo qual será multiplicado o valor base de velocidade
   */
  public abstract float speedMultiplier { get; set; }
  
  /**
   * Valor pelo qual será multiplicado o valor base de dano
   */
  public abstract float weaponMultiplier { get; set; }

  #endregion

  #region Meus Métodos

  /**
   * Atualiza o valor atual de escudo
   */
  protected virtual void updateSpaceshipShieldStatus () {
    lifeController.maxShield = lifeController.baseShield * (_shieldMultiplier / 50);
    lifeController.actualRegenerationSpeed = lifeController.baseRegenerationSpeed * (_shieldMultiplier / 50);
  }

  /**
   * Atualiza o valor atual de velocidade
   */
  protected void updateSpaceshipSpeedStatus () {
    movementController._actualSpeed = movementController._baseSpeed * (_speedMultiplier / 50);
  }

  /**
   * Atualiza o valor atual de dano
   */
  protected void updateSpaceshipWeaponStatus () {
    attackController.actualShootPower = attackController.baseShootPower * (_weaponMultiplier / 50);
  }

  #endregion
}
