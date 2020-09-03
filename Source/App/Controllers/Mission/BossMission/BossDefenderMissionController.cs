using Assets.Source.App.Controllers.Other;
using Assets.Source.App.Controllers.Respawn;
using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Mission.BossMission {

  /// <summary>
  /// Classe responsável por gerenciar a missão do boss focado em defesa
  /// </summary>
  public class BossDefenderMissionController : BossMissionController {

    #region Campos

    /// <summary>
    /// As zonas de respawn. Usadas para o estágio dos kamikazes
    /// </summary>
    [HideInInspector] public RespawnZones respawnZones;

    #endregion

    #region Propriedades

    /// <summary>
    /// Controlador de movimentos do jogador
    /// </summary>
    public new ISpecialMovement playerMovement =>
      (ISpecialMovement) base.playerMovement
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Inicia o respawn de kamikazes quando o boss está fora da tela.
    /// Move o jogador para a posição inicial depois que todos os kamikazes estiverem mortos.
    /// 
    /// Faz o boss atacar quando ele está na posição inicial e parar de atacar quando não está.
    /// </summary>
    public override void updateBoss () {
      if (bossMovement.positionIs(bossMovement.startingPosition)) {
        if (
          bossAttack.normalAttackCoroutine.isPlaying(null) &&
          bossAttack.specialAttackCoroutine.isPlaying(null) &&
          bossMovement.movementCoroutine.isPlaying(
            bossMovement.switchMovements(bossMovement.movementCoroutine.coroutine)
          ) 
        ) {
          bossAttack.normalAttackCoroutine.play(bossAttack.normalAttack());
          bossAttack.specialAttackCoroutine.play(bossAttack.specialAttack());
        }
      } else {
        bossAttack.normalAttackCoroutine.stop();
        bossAttack.specialAttackCoroutine.stop();
      }
    }

    /// <summary>
    /// Move o jogador para o centro da tela e troca para a forma de movimentação especial 
    /// quando o boss está na posição especial.
    /// Move o jogador para a posição inicial e troca para a forma de movimentação normal
    /// quando o boss está na posição normal.
    /// </summary>
    public override void updatePlayer () {
      if (bossMovement.positionIs(bossMovement.specialPosition.Value)) {
        if (playerMovement.movementCoroutine.isPlaying(playerMovement.normalMovement())) {
          playerMovement.movementCoroutine.play(
            playerMovement.switchMovements(playerMovement.movementCoroutine.coroutine)
          );
          fixPlayerScreenView();
        }
      } else {
        if (playerMovement.movementCoroutine.isPlaying(playerMovement.specialMovement())) {
          if (FindObjectsOfType<KamikazeController>().Length == 0) {
            playerMovement.movementCoroutine.play(
              playerMovement.switchMovements(playerMovement.movementCoroutine.coroutine)
            );
            fixPlayerScreenView();
          }
        }
      }
    }

    /// <summary>
    /// Começa o respawn de kamikazes quando o boss está na posição inicial e para o respawn quando ele não está.
    /// </summary>
    public override void updateOthers () {
      if (bossMovement.positionIs(bossMovement.specialPosition.Value)) {
        if (respawnController.respawnCoroutine.isPlaying(null)) {
          respawnController.respawnCoroutine.play(respawnController.specialRespawn());
        }
      } else {
        if (respawnController.respawnCoroutine.isPlaying(respawnController.specialRespawn())) {
          respawnController.respawnCoroutine.stop();
        }
      }
    }


    #endregion

  }
}
