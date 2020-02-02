using Delegates;

using Extensions;

using Interfaces.Missions;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar as missões
/// </summary>
public abstract class MissionController : MonoBehaviour, INormalMission {

  #region Variáveis

  /// <summary>
  /// Controlador de movimento do jogador
  /// </summary>
  public PlayerMovementController _playerMovementController { protected get; set; }

  /// <summary>
  /// Controlador de ataque do jogador
  /// </summary>
  public PlayerAttackController _playerAttackController { protected get; set; }

  /// <summary>
  /// O estágio atual da missão
  /// </summary>
  public MissionStage missionStage { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Controlador de movimento do jogador
  /// </summary>
  public PlayerMovementController playerMovementController {
    get => _playerMovementController;
  }

  /// <summary>
  /// Controlador de ataque do jogador
  /// </summary>
  public PlayerAttackController playerAttackController {
    get => _playerAttackController;
  }

  /// <summary>
  /// Nave do jogador
  /// </summary>
  public GameObject player {
    get => Mission.spaceship;
    set => Mission.spaceship = value;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Desconta do timer e faz um novo inimigo aparecer caso ele tenha esgotado, reiniciando o timer depois
  /// </summary>
  protected virtual void Update () {
    missionStage?.Invoke();
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Move o jogador para a posição inicial e depois permite livre movimento
  /// </summary>
  public virtual void preNormalMission () {
    if (player.isAt(playerMovementController._startingPosition)) {
      playerMovementController.move = playerMovementController.normalMovement;
      missionStage = normalMission;
    } else {
      playerMovementController.move = null;
      player.moveTowards(playerMovementController._startingPosition, playerMovementController._actualSpeed);
    }
  }

  /// <summary>
  /// Acaba o jogo quando o jogador morre
  /// </summary>
  public virtual void normalMission () {
    if (gameOver()) {
      missionStage = postNormalMission;
    }
  }

  /// <summary>
  /// Estágio pós-missão
  /// </summary>
  public abstract void postNormalMission ();

  /// <summary>
  /// Retorna verdadeiro se o jogador morreu
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o jogador morreu
  /// </returns>
  public virtual bool gameOver () {
    return player == null;
  }

  #endregion

}
