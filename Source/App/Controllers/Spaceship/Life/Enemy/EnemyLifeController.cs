/// <summary>
/// Classe responsável pelo controle da vida dos inimigos
/// </summary>
public abstract class EnemyLifeController : LifeController {

  #region Variáveis

  /// <summary>
  /// O score que será dado ao jogador quando ele destruir essa nave
  /// </summary>
  public int scoreReward;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Escudo máximo da nave
  /// </summary>
  public override float maxShield { 
    get => _maxShield;
    set => _maxShield = value;
  }

  #endregion

}
