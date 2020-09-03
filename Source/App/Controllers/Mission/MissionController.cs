using System.Collections;

using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Interfaces.Attacks;
using Assets.Source.App.Utils.Interfaces.Missions;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Mission {

  /// <summary>
  /// Classe responsável por gerenciar as missões
  /// </summary>
  public class MissionController : MonoBehaviour, INormalMission {

    #region Campos

    /// <summary>
    /// Controlador de ataque do jogador
    /// </summary>
    [HideInInspector] public IAttack playerAttack;

    /// <summary>
    /// Controlador de movimento do jogador
    /// </summary>
    [HideInInspector] public IMovement playerMovement;

    [HideInInspector] public CoroutineController missionCoroutine;

    //[HideInInspector] public InputSystem.Input inputs;

    #endregion

    #region Propriedades

    /// <summary>
    /// Nave do jogador
    /// </summary>
    public GameObject player => 
      PlayerData.spaceship
    ;

    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// Move o jogador para a posição inicial e depois permite livre movimento
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    public virtual IEnumerator onNormalMissionStart () {
      yield return new WaitUntil(() => playerMovement != null);
      playerMovement.movementCoroutine.stop();
      while (playerMovement.positionIs(playerMovement.startingPosition) == false) {
        yield return new WaitForFixedUpdate();
        playerMovement.moveTowards(
          playerMovement.startingPosition,
          playerMovement.actualSpeed
        );
      }
      playerMovement.movementCoroutine.play(playerMovement.normalMovement());
      missionCoroutine.play(onNormalMission());
    }

    public virtual IEnumerator onNormalMission () {
      missionCoroutine.play(onMission(onNormalMissionEnd()));
      yield return null;
    }

    public virtual IEnumerator onNormalMissionEnd () {
      yield return new WaitUntil(() => true);//-----------------------------------------------
      Game.loadScene(Scenes.Menu);
    }

    /// <summary>
    /// Passa para nextStage quando o jogador morre ou aperta esc
    /// </summary>
    /// 
    /// <param name="nextStage">
    /// O estágio da missão que deve ser iniciado
    /// </param>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    public IEnumerator onMission (IEnumerator nextStage) {
      yield return new WaitUntil(() => gameOver() || Input.GetKeyDown(KeyCode.Escape));
      missionCoroutine.play(nextStage);
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Retorna verdadeiro se o jogador morreu
    /// </summary>
    /// 
    /// <returns>
    /// Verdadeiro se o jogador morreu
    /// </returns>
    protected virtual bool gameOver () {
      return player == null;
    }

    #endregion

    #region Métodos da Unity

    private void OnEnable () {
      //inputs?.Enable();
    }

    private void OnDisable () {
      //inputs?.Disable();
    }

    #endregion

  }
}
