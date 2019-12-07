using UnityEngine;

/**
 * Controla o comportamento da vida da nave
 */
public abstract class LifeController : MonoBehaviour {

  #region Variáveis

  /**
   * Referência do escudo que aparece ao redor da nave na tela
   */
  public GameObject shieldSphere;

  /**
   * Guardam o valor escudo e o máximo que o escudo pode atingir
   */
  public float _hp, _shield, _maxShield;

  /**
   * Regeneração base do escudo.
   */
  public float baseRegenerationSpeed;

  /**
   * Regeneração atual/verdadeira do escudo
   */
  public float actualRegenerationSpeed;

  /**
   * Valor base do escudo
   */
  public float baseShield;

  /**
   * Se o player está vivo ou morto
   */
  public bool dead;

  #endregion

  #region Getters e Setters

  public float hp {
    get => _hp;
    set {
      _hp = value;
      onHpValueChange();
    }
  }

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

  /**
   * Regenera o escudo quando o timer esgota e destrói o objeto caso ele tenha morrido
   */
  protected virtual void Update () {
    shield += Time.deltaTime * baseRegenerationSpeed;
  }

  #endregion

  #region Meus métodos

  protected virtual void onHpValueChange () {
    if (hp <= 0) {
      dead = true;
    }
  }

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
