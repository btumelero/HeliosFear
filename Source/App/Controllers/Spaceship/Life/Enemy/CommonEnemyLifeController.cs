using Assets.Source.App.Controllers.Spaceship.Attack;
using Assets.Source.App.Data.Mission;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Life.Enemy {

  /// <summary>
  /// Classe responsável por controlar a vida dos inimigos comuns
  /// </summary>
  public class CommonEnemyLifeController : EnemyLifeController {

    #region Meus Métodos

    /// <summary>
    /// Aumenta e persiste o highscore do jogador
    /// </summary>
    public void giveScore () {
      GameObject player = PlayerData.spaceship;
      if (player != null) {
        PlayerAttackController playerController = player.GetComponent<PlayerAttackController>();
        if (player != null) {
          playerController.score.Value += scoreReward;
        }
      }
    }

    /// <summary>
    /// Destrói a nave caso ela esteja morta.
    /// Dá score pro jogador e chama o método que é responsável pelo pooling
    /// </summary>
    protected override void onDeath () {
      giveScore();
      gameObject.SetActive(false);
    }

    #endregion

  }
}
