using Enums;

using Extensions;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a missão do boss focado em defesa
/// </summary>
public class BossDefenderMissionController : BossMissionController {

  #region Variáveis

  /// <summary>
  /// As zonas de respawn. Usadas para o estágio dos kamikazes
  /// </summary>
  public RespawnZones respawnZones { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Controlador de movimentos do boss
  /// </summary>
  public new BossEnemyDefenderMovementController bossMovementController {
    get => (BossEnemyDefenderMovementController) _bossEnemyMovementController;
  }

  /// <summary>
  /// Controlador de ataques do boss
  /// </summary>
  public new BossEnemyDefenderAttackController bossAttackController {
    get => (BossEnemyDefenderAttackController) _bossEnemyAttackController;
  }

  /// <summary>
  /// Controlador de movimentos do jogador
  /// </summary>
  public new PlayerSpecialMovementController playerMovementController {
    get => (PlayerSpecialMovementController) _playerMovementController;
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Inicializa o tempo entre o respawn de kamikazes
  /// </summary>
  public override void preBossMission () {
    base.preBossMission();
    respawnController.respawnTimer.baseTime = 0.3f;
  }

  /// <summary>
  ///  e inicia o respawn de kamikazes quando o boss está fora da tela.
  /// Move o jogador para a posição inicial depois que todos os kamikazes estiverem mortos.
  /// 
  /// Faz o boss atacar quando ele está na posição inicial e parar de atacar quando não está.
  /// </summary>
  public override void updateBoss () {
    if (boss.isAt(bossMovementController.startingPosition)) {
      if (bossAttackController.specialShootTimer.enabled == false) {
        bossAttackController.specialShootTimer.enabled = true;
        bossAttackController.specialShootTimer.baseTime = Random.Range(7, 10);
      }
      bossAttackController.attack = bossAttackController.normalAttack;
      bossAttackController.attack += bossAttackController.specialAttack;
    } else {
      if (bossAttackController.attack != null) {
        bossAttackController.attack = null;
        bossAttackController.specialShootTimer.enabled = false;
      }
    }
  }

  /// <summary>
  /// Move o jogador para o centro da tela e troca para a forma de movimentação especial 
  /// quando o boss está na posição especial.
  /// Move o jogador para a posição inicial e troca para a forma de movimentação normal
  /// quando o boss está na posição normal.
  /// </summary>
  public override void updatePlayer () {
    if (boss.isAt(bossMovementController.specialPosition)) {
      if (playerMovementController.move == playerMovementController.normalMovement) {
        playerMovementController.move = playerMovementController.switchToSpecialMovement;
        fixPlayerScreenView();
      }
    } else {
      if (playerMovementController.move == playerMovementController.specialMovement) {
        if (GameObject.FindGameObjectsWithTag(Tags.Enemy.ToString()).Length == 0) {
          playerMovementController.move = playerMovementController.switchToNormalMovement;
          fixPlayerScreenView();
        }
      }
    }
  }

  /// <summary>
  /// Começa o respawn de kamikazes quando o boss está na posição inicial e para o respawn quando ele não está.
  /// </summary>
  public override void updateOthers () {
    if (boss.isAt(bossMovementController.specialPosition)) {
      if (respawnController.respawn == null) {
        respawnController.respawn = respawnController.specialRespawn;
      }
    } else {
      if (respawnController.respawn == respawnController.specialRespawn) {
        respawnController.respawn = null;
      }
    }
  }


  #endregion

}
