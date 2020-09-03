using UnityEngine;

/// <summary>
/// Controla o comportamento da vida da nave
/// </summary>
public abstract class LifeController : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// Referência do escudo que aparece ao redor da nave na tela
  /// </summary>
  public GameObject shieldSphere;

  /// <summary>
  /// Timer que controla o tempo que o escudo leva para voltar a regenerar após ser esgotado
  /// </summary>
  public Timer shieldRegenerationDelayTimer { get; set; }

  /// <summary>
  /// Guarda o valor do hp
  /// </summary>
  public float _hp;

  /// <summary>
  /// Guarda o valor do escudo
  /// </summary>
  public float _shield;

  /// <summary>
  /// Guarda o valor máximo que o escudo pode atingir
  /// </summary>
  public float _maxShield;

  /// <summary>
  /// Regeneração base do escudo.
  /// </summary>
  public float baseRegeneration;

  /// <summary>
  /// Regeneração atual/verdadeira do escudo
  /// </summary>
  public float actualRegeneration;

  /// <summary>
  /// Valor base do escudo
  /// </summary>
  public float baseShield;

  /// <summary>
  /// Se o player está vivo ou morto
  /// </summary>
  public bool dead;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Atualiza o hp e chama método que faz outras alterações que devem ser feitas ao mudar o hp
  /// </summary>
  public float hp {
    get => _hp;
    set {
      _hp = value;
      onHpValueChange();
    }
  }

  /// <summary>
  /// Atualiza o escudo e chama método que faz outras alterações que devem ser feitas ao mudar o escudo
  /// </summary>
  public float shield {
    get => _shield;
    set {
      _shield = value;
      onShieldValueChange();
    }
  }

  /// <summary>
  /// Deve ser implementado por subclasses para definir o comportamento em mudanças no valor
  /// </summary>
  public abstract float maxShield { get; set; }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Regenera o escudo gradualmente se o delay pós destruição do escudo esgotou
  /// </summary>
  protected virtual void Update () {
    if (shieldRegenerationDelayTimer) {
      if (shieldRegenerationDelayTimer.timeIsUp()) {
        shield += Time.deltaTime * baseRegeneration;
      }
    }
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Disparado ao mudar o valor do hp.
  /// </summary>
  protected virtual void onHpValueChange () {
    if (hp <= 0) {
      dead = true;
    }
  }

  /// <summary>
  /// Disparado ao mudar o valor do escudo.
  /// Reseta o timer de delay de regeneração quando o escudo for destruído e esconde a esfera que representa o escudo
  /// Caso o dano dado seja maior que o escudo restante, transfere o dano para o hp da nave.
  /// Mantém o escudo ativo caso ele ainda não tenha sido destruído
  /// </summary>
  protected virtual void onShieldValueChange () {
    if (_shield <= 0) {
      shieldRegenerationDelayTimer.restart();
      setShieldSphereEnabled(false);
    }
    if (_shield < 0) {
      hp += _shield;
    } else {
      setShieldSphereEnabled(true);
    }
    _shield = Mathf.Clamp(_shield, 0, maxShield);
  }

  /// <summary>
  /// Desativa e esconde o escudo da nave
  /// </summary>
  /// 
  /// <param name="value">
  /// Se deve ser ativado ou destativado
  /// </param>
  private void setShieldSphereEnabled (bool value) {
    if (shieldSphere != null) {
      shieldSphere.GetComponent<Collider>().enabled = value;
      shieldSphere.GetComponent<MeshRenderer>().enabled = value;
    }

  }

  #endregion

}
