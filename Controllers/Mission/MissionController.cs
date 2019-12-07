using Delegates;

using Extensions;

using Interfaces.Missions;

using UnityEngine;

public abstract class MissionController : MonoBehaviour, INormalMission {

  #region Variáveis

  public PlayerMovementController _playerMovementController { protected get; set; }
  public PlayerAttackController _playerAttackController { protected get; set; }
  public MissionStage missionStage { get; set; }

  #endregion

  #region Getters e Setters

  public PlayerMovementController playerMovementController {
    get => _playerMovementController;
  }

  public PlayerAttackController playerAttackController {
    get => _playerAttackController;
  }

  public GameObject player {
    get => Mission.spaceship;
    set => Mission.spaceship = value;
  }

  #endregion

  #region Métodos da Unity

  /**
   * Update is called once per frame
   * Desconta do timer e faz um novo inimigo aparecer caso ele tenha esgotado, reiniciando o timer depois
   */
  protected virtual void Update () {
    if (missionStage != null) {
      missionStage();
    }
  }

  #endregion

  #region Meus Métodos

  public virtual void preNormalMission () {
    if (player.isAt(playerMovementController._startingPosition)) {
      playerMovementController.move = playerMovementController.normalMovement;
      missionStage = normalMission;
    } else {
      playerMovementController.move = null;
      player.moveTowards(playerMovementController._startingPosition, playerMovementController._actualSpeed);
    }
  }

  public virtual void normalMission () {
    playerMovementController.move = playerMovementController.normalMovement;
    if (gameOver()) {
      missionStage = postNormalMission;
    }
  }

  public abstract void postNormalMission ();

  public virtual bool gameOver () {
    return player == null;
  }

  #endregion

}
