using UnityEngine;

/**
 * Responsável pelas inicializações de variáveis relacionadas à nave.
 * O objetivo dessa classe é centralizar as inicializações para evitar problemas relacionados à ordem de execução de scripts 
 */
public abstract class SpaceshipConstructor : MonoBehaviour {

  #region Variáveis

  /**
   * Referência do controlador de ataque da nave que tem esse script 
   */
  protected AttackController _attackController;

  /**
   * Referência do controlador de energia da nave que tem esse script 
   */
  protected EnergyController _energyController;

  /**
   * Referência do controlador de vida da nave que tem esse script 
   */
  protected LifeController _lifeController;

  /**
   * Referência do controlador de movimento da nave que tem esse script 
   */
  protected MovementController _movementController;

  #endregion

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   * 
   * Chamando os métodos que inicializam a nave
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



  /**
   * Inicializa o ataque
   */
  protected virtual void setUpAttack () {
    _attackController.shootTimer = gameObject.AddComponent<Timer>();
  }

  /**
   * Inicializa a energia
   */
  protected virtual void setUpEnergy () {
    _energyController.attackController = _attackController;
    _energyController.lifeController = _lifeController;
    _energyController.movementController = _movementController;
  }

  /**
   * Inicializa a vida
   */
  protected virtual void setUpLife () {
    _lifeController.shieldSphere = GetComponentInChildren<SphereCollider>().gameObject;
  }

  /**
   * Inicializa o movimento
   */
  protected abstract void setUpMovement ();

  /**
   * Inicializa o score
   */
  protected abstract void setUpScore ();

  /**
   * Inicializa esse objeto
   */
  private void setUpConstructor () {
    _attackController = GetComponent<AttackController>();
    _energyController = GetComponent<EnergyController>();
    _lifeController = GetComponent<LifeController>();
    _movementController = GetComponent<MovementController>();
  }

  #endregion
}
