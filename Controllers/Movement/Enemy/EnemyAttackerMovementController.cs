using UnityEngine;

public class EnemyAttackerMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * Esse tipo de nave se move na direção do jogador
   */
  public override void directionSwitch () {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null) {
      float posicaoHorizontalDoJogador = player.transform.position.x;
      moving =
        posicaoHorizontalDoJogador > transform.position.x ?
          movementType.RIGHTWARD
          :
        posicaoHorizontalDoJogador < transform.position.x ?
          movementType.LEFTWARD
          :
          movementType.DOWNWARD
      ;
    }
  }

  /*
   * Move a nave na direção horizontal do jogador, para baixo e mantém o eixo profundidade como zero
   */
  protected override void updateMovementDirection () {
    spaceship.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (moving == movementType.DOWNWARD ? 0 : moving == movementType.RIGHTWARD ? actualSpeed : -actualSpeed),
      -actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

  #region Métodos da Unity

  
  protected override void FixedUpdate () {
    base.FixedUpdate();
  }

  /*
   * Start is called before the first frame update
   * Dá uma velocidade e tempo entre troca de direção random inicial para essa nave
   */
  protected override void Start () {
    base.Start();
    switchTimer.baseTime = Random.Range(3, 5);
    baseSpeed = 125;
  }

  #endregion

}
