using Enums;
using UnityEngine;

public class CommonEnemyAttackerMovementController : CommonEnemyMovementController {

  #region Getters e Setters

  public GameObject player {
    get => Mission.spaceship;
  }

  #endregion

  #region Métodos da Unity

  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Attacker, gameObject);
  }

  #endregion

  #region Meus métodos

  /*
   * Esse tipo de nave se move na direção do jogador
   */
  public override void directionSwitch () {
    if (player != null) {
      float posicaoHorizontalDoJogador = player.transform.position.x;
      moving =
        posicaoHorizontalDoJogador > transform.position.x ?
          Movement.Rightward
          :
        posicaoHorizontalDoJogador < transform.position.x ?
          Movement.Leftward
          :
          Movement.Downward
      ;
    }
  }

  /**
   * Move a nave na direção horizontal do jogador, para baixo e mantém o eixo profundidade como zero
   */
  protected override void updateMovementDirection () {
    spaceshipBody.velocity = new Vector3(
      (moving == Movement.Downward ?
         0
         :
       moving == Movement.Rightward ?
         _actualSpeed
         :
         -_actualSpeed
      ) * (Time.fixedDeltaTime * 3),
      -_actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
