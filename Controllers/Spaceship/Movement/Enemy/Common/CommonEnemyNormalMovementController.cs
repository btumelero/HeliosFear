using Enums;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a movimentação do inimigo normal
/// </summary>
public class CommonEnemyNormalMovementController : CommonEnemyMovementController {

  #region Métodos da Unity

  /// <summary>
  /// Armazena o inimigo para reutilização quando ele não está mais visível usando a técnica Pooling
  /// </summary>
  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Normal, gameObject);
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Esse tipo de nave se move para esquerda, direita e baixo.
  /// Esse método randomiza entre as três.
  /// </summary>
  public override void directionSwitch () {
    moving = (Enums.Movement) Random.Range(0, 3);
  }

  /// <summary>
  /// Atualiza a direção em que a nave está indo
  /// </summary>
  protected override void updateMovementDirection () {
    spaceshipBody.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (
        moving == Enums.Movement.Downward ? 0 : moving == Enums.Movement.Rightward ? _actualSpeed : -_actualSpeed
      ),
      -_actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
