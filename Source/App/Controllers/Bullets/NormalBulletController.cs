/// <summary>
/// Classe responsável por gerenciar tiros normais
/// </summary>
public class NormalBulletController : BulletController {

  #region Meus Métodos

  /// <summary>
  /// Dá dano no escudo e exibe um efeito
  /// </summary>
  /// 
  /// <param name="lifeController">
  /// O controlador de vida da nave
  /// </param>
  public override void hitShield (LifeController lifeController) {
    base.hitShield(lifeController);
    showEffect();
  }

  /// <summary>
  /// Dá dano na nave e exibe um efeito
  /// </summary>
  /// 
  /// <param name="lifeController">
  /// O controlador de vida da nave
  /// </param>
  public override void hitSpaceship (LifeController lifeController) {
    base.hitSpaceship(lifeController);
    showEffect();
  }

  /// <summary>
  /// Mostra um efeito e destrói o tiro
  /// </summary>
  protected override void showEffect () {
    base.showEffect();
    Destroy(gameObject);
  }

  #endregion
}
