using UnityEngine;

public class CommonEnemyLifeController : EnemyLifeController {

  #region Meus Métodos

  /**
     * Aumenta e persiste o highscore do jogador
     */
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

  protected override void Update () {
    base.Update();
    if (dead) {
      giveScore();
      GetComponent<CommonEnemyMovementController>().OnBecameInvisible();
    }
  }

  #endregion

}
