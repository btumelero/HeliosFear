using UnityEngine;

public class CommonEnemyAttackerMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * Esse tipo de nave se move na direção do jogador
   */
  public override void directionSwitch () {
    GameObject player = GameObject.FindGameObjectWithTag(Enums.Tags.Player.ToString());
    if (player != null) {
      float posicaoHorizontalDoJogador = player.transform.position.x;
      moving =
        posicaoHorizontalDoJogador > transform.position.x ?
          Enums.Movement.Rightward
          :
        posicaoHorizontalDoJogador < transform.position.x ?
          Enums.Movement.Leftward
          :
          Enums.Movement.Downward
      ;
    }
  }

  /*
   * Move a nave na direção horizontal do jogador, para baixo e mantém o eixo profundidade como zero
   */
  protected override void updateMovementDirection () {
    spaceship.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (
        moving == Enums.Movement.Downward ? 0 : moving == Enums.Movement.Rightward ? actualSpeed : -actualSpeed
      ),
      -actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
