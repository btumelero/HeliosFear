public class EnemyLifeController : LifeController {

  #region Variáveis

  public EnemyConstructor enemyConstructor { get; set; }

  #endregion

  #region Getters e Setters

  public override float hp {
    get => _hp;
    set {
      _hp = value;
      if (_hp <= 0) {
        dead = true;
        enemyConstructor.giveScore();
      }
    }
  }

  public override float maxShield { get; set; }

  #endregion

}
