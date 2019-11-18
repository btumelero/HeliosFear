using UnityEngine;

public abstract class EnemyConstructor : SpaceshipController {

  #region Variáveis

  public GameObject powerDown, powerUp;
  protected int scoreReward { get; set; }

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    GetComponent<EnemyMovementController>().directionSwitch();
  }

  #endregion

  #region Meus Métodos

  /*
   * Aumenta o score do player e tem uma chance de criar um power up/down quando destruído
   */
  public void spawnPower () {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null) {
      PlayerController playerController = player.GetComponentInParent<PlayerController>();
      giveScore(playerController);
      int random = Random.Range(0, 100);
      if (random < 15) {
        instantiateAndMovePower(powerDown);
      } else if (random >= 90) {
        instantiateAndMovePower(powerUp);
      }
    }
  }

  /*
   * Cria e faz um power up/down se mover para baixo
   */
  private void instantiateAndMovePower (GameObject power) {
    GameObject newPower = Instantiate(
      power, 
      new Vector3(transform.position.x, transform.position.y, 0), 
      power.transform.rotation
    );
    newPower.GetComponent<Rigidbody>().velocity = Vector3.down * 150 * Time.deltaTime;
  }

  /*
   * Provisório: aumenta e salva nas preferências do jogador o highscore dele
   */
  private void giveScore (PlayerController player) {
    if (player != null) {
      player.score += scoreReward;
    }
  }

  #endregion

}

