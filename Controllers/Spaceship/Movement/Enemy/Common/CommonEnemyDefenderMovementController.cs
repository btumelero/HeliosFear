using Enums;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a movimentação do inimigo focado em defesa
/// </summary>
public class CommonEnemyDefenderMovementController : CommonEnemyMovementController {

  #region Métodos da Unity

  /// <summary>
  /// Armazena o inimigo para reutilização quando ele não está mais visível usando a técnica Pooling
  /// </summary>
  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Defender, gameObject);
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Esse tipo de nave defender se move para baixo ou fica parada.
  /// Esse método randomiza entre os dois
  /// </summary>
  public override void directionSwitch () {
    moving = (Movement) Random.Range(2, 4);
  }

  /// <summary>
  /// Atualiza a direção em que a nave está indo
  /// </summary>
  protected override void updateMovementDirection () {
    spaceshipBody.velocity = new Vector3(
      0,
      (Time.fixedDeltaTime * 3) * (moving == Movement.Downward ? -_actualSpeed : 0),
      0
    );
  }

  #endregion

}
