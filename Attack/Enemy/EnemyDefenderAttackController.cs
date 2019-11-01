using UnityEngine;

public class EnemyDefenderAttackController : EnemyAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade e a potência base do tiro e randomiza o tempo entre disparos
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = Random.Range(3, 6);
    shootVelocity = 20;
    baseShootPower = 4;
  }

  #endregion

  #region Meus Métodos

  /*
   * Calcula o ângulo em que o tiro deve ser disparado e 
   * transforma o resultado em um vetor com valores de 0~1 pra unity poder usar o vetor
   */
  private Vector3 shotAt (GameObject player) {
    return (player.transform.position - shootPositions[0].position).normalized;
  }

  /*
   * Esse tipo de nave atira um tiro na direção do jogador
   */
  protected override void shootAppropriateNumberOfShoots () {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null) {
      instantiateAndMoveBullet(shootPositions[0], shotAt(player));
    }
  }

  #endregion

}
