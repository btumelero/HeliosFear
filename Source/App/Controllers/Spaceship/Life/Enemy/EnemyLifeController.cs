using Assets.Source.App.Data.Spaceship;

namespace Assets.Source.App.Controllers.Spaceship.Life.Enemy {

  /// <summary>
  /// Classe responsável pelo controle da vida dos inimigos
  /// </summary>
  public abstract class EnemyLifeController : LifeController {

    #region Propriedades

    /// <summary>
    /// O score que será dado ao jogador quando ele destruir essa nave
    /// </summary>
    public int scoreReward {
      get => SpaceshipData.values[gameObject.tag].lifeData.scoreReward;
    }

    #endregion

  }

}
