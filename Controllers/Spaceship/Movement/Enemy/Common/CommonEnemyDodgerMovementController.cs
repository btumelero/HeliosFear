using Enums;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a movimentação do inimigo rápido
/// </summary>
public class CommonEnemyDodgerMovementController : CommonEnemyMovementController {

  #region Métodos da Unity

  /// <summary>
  /// Armazena o inimigo para reutilização quando ele não está mais visível usando a técnica Pooling
  /// </summary>
  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Dodger, gameObject);
  }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Esse tipo de nave se move para esquerda e direita.
  /// Esse método randomiza entre os dois
  /// </summary>
  public override void directionSwitch () {
    moving = (Movement) Random.Range(0, 2);
  }

  /// <summary>
  /// Atualiza a direção em que a nave está indo
  /// </summary>
  protected override void updateMovementDirection () {
    spaceshipBody.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (moving == Movement.Rightward ? _actualSpeed : -_actualSpeed),
      -_actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
