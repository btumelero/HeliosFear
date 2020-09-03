using Assets.Source.Experimental;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Life.Enemy.Boss {

  /// <summary>
  /// Classe responsável por controlar a vida de boss
  /// </summary>
  public class BossEnemyLifeController : EnemyLifeController {

    #region Campos

    /// <summary>
    /// O collider do corpo da nave
    /// </summary>
    [HideInInspector] public Collider spaceshipBodyCollider;

    /// <summary>
    /// Se o boss pode tomar dano ou não
    /// </summary>
    public FieldWithAction<bool> vulnerable;

    #endregion

    #region Propriedades

    /// <summary>
    /// Retorna verdadeiro se a nave está vulnerável e 
    /// torna a nave invulnerável ao settar false.
    /// </summary>
    public void onVulnerableValueChanged () {
      if (spaceshipBodyCollider != null) {
        spaceshipBodyCollider.enabled = vulnerable.Value;
      }
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Retorna verdadeiro se o escudo deveria estar ativado no momento da execução
    /// </summary>
    /// 
    /// <returns>
    /// Verdadeiro se há escudo e se ele está se movimentando em arcos na tela
    /// </returns>
    protected override bool shieldShouldBeEnabled () {
      return base.shieldShouldBeEnabled() && vulnerable.Value;
    }

    /// <summary>
    /// Destrói a nave caso ela esteja morta.
    /// Isso é feito aqui para evitar que a nave seja destruída antes 
    /// que outra parte do código tente modificar alguma coisa
    /// </summary>
    protected override void onDeath () {
      Destroy(gameObject);
    }

    #endregion

    #region Métodos da Unity

    private void OnBecameInvisible () {
      vulnerable.Value = true;
    }

    private void OnBecameVisible () {
      vulnerable.Value = false;
    }

    #endregion

  }
}
