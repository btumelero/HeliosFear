using Assets.Source.App.Data.Spaceship;

using UnityEngine;
using Assets.Source.App.Utils.Coroutines;
using System.Collections;
using Assets.Source.Experimental;

namespace Assets.Source.App.Controllers.Spaceship.Life {

  /// <summary>
  /// Controla o comportamento da vida da nave
  /// </summary>
  public abstract class LifeController : MonoBehaviour {

    #region Campos

    /// <summary>
    /// Collider do escudo que aparece ao redor da nave na tela
    /// </summary>
    [HideInInspector] public Collider shieldSphereCollider;

    /// <summary>
    /// Renderizador do escudo que aparece ao redor da nave na tela
    /// </summary>
    [HideInInspector] public Renderer shieldSphereRenderer;

    /// <summary>
    /// Guarda o valor do hp
    /// </summary>
    public FieldWithAction<float> hp;

    /// <summary>
    /// Guarda o valor do escudo
    /// </summary>
    public FieldWithAction<float> shield;

    /// <summary>
    /// Guarda o valor máximo que o escudo pode atingir
    /// </summary>
    public FieldWithAction<float> maxShield;

    /// <summary>
    /// Regeneração verdadeira do escudo
    /// </summary>
    public float actualRegeneration;

    /// <summary>
    /// Se o player está vivo ou morto
    /// </summary>
    public bool dead;

    #endregion

    #region Propriedades

    public CoroutineController lifeCoroutine { get; set; }

    /// <summary>
    /// O tempo que o escudo leva para voltar a regenerar após ser esgotado
    /// </summary>
    public float shieldRegenerationDelayTimer =>
      SpaceshipData.values[gameObject.tag].lifeData.shieldRegenerationDelayTimer
    ;

    /// <summary>
    /// Regeneração base do escudo.
    /// </summary>
    public virtual float baseRegeneration =>
      SpaceshipData.values[gameObject.tag].lifeData.baseRegeneration
    ;

    /// <summary>
    /// Valor base do escudo
    /// </summary>
    public virtual float baseShield =>
      SpaceshipData.values[gameObject.tag].lifeData.baseShield
    ;

    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// Regenera o escudo gradualmente se o delay pós destruição do escudo esgotou
    /// </summary>
    public IEnumerator regenerateShield () {
      while (true) {
        if (shield.Value <= 0f) {
          yield return new WaitForSeconds(shieldRegenerationDelayTimer);
        }
        shield.Value += Time.deltaTime * actualRegeneration;
        yield return null;
      }
    }

    #endregion

    #region Meus Métodos

    protected abstract void onDeath ();

    /// <summary>
    /// Disparado ao mudar o valor do hp.
    /// </summary>
    public virtual void onHpValueChange () {
      if (hp.Value <= 0f) {
        dead = true;
        hp.onValueChange -= onHpValueChange;
        shield.onValueChange -= onShieldValueChange;
      }
    }

    /// <summary>
    /// Disparado ao mudar o valor do escudo.
    /// Reseta o timer de delay de regeneração quando o escudo for destruído 
    /// e esconde a esfera que representa o escudo.
    /// Caso o dano dado seja maior que o escudo restante, transfere o dano para o hp da nave.
    /// Mantém o escudo ativo caso ele ainda não tenha sido destruído
    /// </summary>
    public virtual void onShieldValueChange () {
      if (shield.Value < 0f && dead == false) {
        hp.Value += shield.Value;
      }
      setShieldSphereEnabled(shieldShouldBeEnabled());
      shield._Value = Mathf.Clamp(shield.Value, 0, maxShield.Value);
    }

    /// <summary>
    /// Retorna verdadeiro se o escudo deveria estar ativado
    /// </summary>
    /// 
    /// <returns>
    /// Verdadeiro se o escudo for maior que zero
    /// </returns>
    protected virtual bool shieldShouldBeEnabled () {
      return shield.Value > 0f;
    }

    /// <summary>
    /// Desativa e esconde o escudo da nave
    /// </summary>
    /// 
    /// <param name="value">
    /// Se deve ser ativado ou destativado
    /// </param>
    private void setShieldSphereEnabled (bool value) {
      if (shieldSphereCollider != null && shieldSphereRenderer != null) {
        shieldSphereCollider.enabled = value;
        shieldSphereRenderer.enabled = value;
      }
    }

    #endregion

    #region Métodos da Unity

    private void Update () {
      if (dead) {
        onDeath();
      }
    }

    #endregion

  }
}
