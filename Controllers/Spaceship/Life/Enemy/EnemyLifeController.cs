public abstract class EnemyLifeController : LifeController {

  #region Variáveis

  /**
   * O score que será dado ao jogador quando ele destruir essa nave
   */
  public int scoreReward;

  #endregion

  #region Getters e Setters

  public override float maxShield { 
    get => _maxShield;
    set => _maxShield = value;
  }

  #endregion

}
