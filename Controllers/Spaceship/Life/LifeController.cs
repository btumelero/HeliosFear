using UnityEngine;

/*
 * Responsável pelo hp e pelo shield da nave
 */
public abstract class LifeController : MonoBehaviour {

  #region Variáveis

  public GameObject shieldSphere;
  protected float _hp, _shield, _maxShield;
  public AbstractTimer regenerationTimer { get; set; }
  public float baseShield { get; protected set; }
  public bool dead { get; protected set; }

  #endregion

  #region Getters e Setters

  public abstract float hp { get; set; }

  public float shield {
    get => _shield;
    set {
      _shield = value;
      onShieldValueChange();
    }
  }

  public abstract float maxShield { get; set; }

  #endregion

  #region Métodos da Unity

  /*
   * Regenera o escudo quando o timer esgota e destrói o objeto caso ele tenha morrido
   */
  protected virtual void Update () {
    if (regenerationTimer.timeIsUp()) {
      shield++;
      regenerationTimer.restart();
    }
    if (dead) {
      Destroy(gameObject);
    }
  }

  /*
   * Pegando referência e inicializando
   */
  protected virtual void Start () {
    dead = false;
  }

  #endregion

  #region Meus métodos

  protected virtual void onShieldValueChange () {
    if (_shield <= 0) {
      setShieldSphereEnabled(false);
    }
    if (_shield < 0) {
      hp += _shield;
    } else {
      setShieldSphereEnabled(true);
    }
    _shield = Mathf.Clamp(_shield, 0, maxShield);
  }

  protected virtual void onHpValueChange () {
    if (_hp <= 0) {
      dead = true;
    }
  }

  /*
   * Desativa o escudo da nave
   */
  private void setShieldSphereEnabled (bool value) {
    if (shieldSphere != null) {
      shieldSphere.GetComponent<Collider>().enabled = value;
      shieldSphere.GetComponent<MeshRenderer>().enabled = value;
    }

  }

  #endregion

}
