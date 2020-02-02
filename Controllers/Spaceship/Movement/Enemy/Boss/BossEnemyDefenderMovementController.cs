using System.Collections.Generic;

using Extensions;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a movimentação do boss focado em defesa
/// </summary>
public class BossEnemyDefenderMovementController : BossEnemyMovementController {

  #region Variáveis

  /// <summary>
  /// A posição do boss quando ele está fora da tela
  /// </summary>
  public Vector3 offscreenPosition;

  /// <summary>
  /// A posição especial do boss na tela
  /// </summary>
  public Vector3 specialPosition;

  /// <summary>
  /// A lista de movimentos que o boss deve executar para chegar na posição desejada
  /// </summary>
  public List<Vector3> movementList { get; set; }

  #endregion

  #region Meus métodos

  /// <summary>
  /// Vai executando cada movimento da lista até completar todos e depois reinicia o timer de movimento
  /// </summary>
  private void moveTowardsDestination () {
    spaceship.moveTowards(movementList[0], actualSpeed);
    if (spaceship.isAt(movementList[0])) {
      movementList.RemoveAt(0);
    }
    if (movementList.Count == 0) {
      movementTypeTimer.restart();
      move = normalMovement;
    }
  }

  /// <summary>
  /// Alterna entre entrar e sair da tela
  /// </summary>
  public override void normalMovement () {
    if (movementTypeTimer.timeIsUp()) {
      movementList.Add(offscreenPosition);
      if (spaceship.isAt(startingPosition)) {
        movementList.Add(specialPosition);
      } else if (spaceship.isAt(specialPosition)) {
        movementList.Add(startingPosition);
      }
      move = moveTowardsDestination;
    }
  }

  #endregion

}
