using UnityEngine;

/// <summary>
/// Responsável pelas inicializações de variáveis relacionadas à nave.
/// O objetivo dessa classe é centralizar as inicializações para evitar problemas relacionados à ordem de execução de scripts
/// </summary>
public abstract class SpaceshipConstructor : MonoBehaviour {

  #region Variáveis

  protected AttackController _attackController;

  protected EnergyController _energyController;

  protected LifeController _lifeController;

  protected MovementController _movementController;

  #endregion

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   */
  protected virtual void Start () {
    setUpConstructor();
    setUpAttack();
    setUpLife();
    setUpMovement();
    setUpEnergy();
    setUpScore();
  }

  #endregion

  #region Meus Métodos

  protected virtual void setUpAttack () {
    _attackController.shootTimer = gameObject.AddComponent<Timer>();
  }

  protected virtual void setUpEnergy () {
    _energyController.attackController = _attackController;
    _energyController.lifeController = _lifeController;
    _energyController.movementController = _movementController;
  }

  protected virtual void setUpLife () {
    _lifeController.shieldSphere = GetComponentInChildren<SphereCollider>().gameObject;
    _lifeController.shieldRegenerationDelayTimer = gameObject.AddComponent<Timer>();
  }

  protected abstract void setUpMovement ();

  protected abstract void setUpScore ();

  private void setUpConstructor () {
    _attackController = GetComponent<AttackController>();
    _energyController = GetComponent<EnergyController>();
    _lifeController = GetComponent<LifeController>();
    _movementController = GetComponent<MovementController>();
  }

  #endregion
}
