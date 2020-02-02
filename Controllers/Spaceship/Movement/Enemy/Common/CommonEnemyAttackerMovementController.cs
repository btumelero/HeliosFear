using Enums;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a movimentação do inimigo focado em ataque
/// </summary>
public class CommonEnemyAttackerMovementController : CommonEnemyMovementController {

  #region Getters e Setters

  /// <summary>
  /// A nave do jogador
  /// </summary>
  public GameObject player {
    get => Mission.spaceship;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Armazena o inimigo para reutilização quando ele não está mais visível usando a técnica Pooling
  /// </summary>
  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Attacker, gameObject);
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Esse tipo de nave se move para baixo e na direção horizontal do jogador
  /// </summary>
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

  /// <summary>
  /// Atualiza a direção em que a nave está indo
  /// </summary>
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
