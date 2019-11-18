using UnityEngine;

public class CommonEnemyDefenderAttackController : EnemyAttackController {
  
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
