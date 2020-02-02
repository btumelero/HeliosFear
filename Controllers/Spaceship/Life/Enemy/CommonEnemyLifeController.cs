using UnityEngine;

/// <summary>
/// Classe responsável por controlar a vida dos inimigos comuns
/// </summary>
public class CommonEnemyLifeController : EnemyLifeController {

  #region Meus Métodos

  /// <summary>
  /// Aumenta e persiste o highscore do jogador
  /// </summary>
  public void giveScore () {
    GameObject player = Mission.spaceship;
    if (player != null) {
      PlayerAttackController playerController = player.GetComponent<PlayerAttackController>();
      if (player != null) {
        playerController.score += scoreReward;
      }
    }
  }


  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Destrói a nave caso ela esteja morta.
  /// Dá score pro jogador e chama o método que é responsável pelo pooling
  /// </summary>
  protected override void Update () {
    base.Update();
    if (dead) {
      giveScore();
      GetComponent<CommonEnemyMovementController>().OnBecameInvisible();
    }
  }

  #endregion

}
