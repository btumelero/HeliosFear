using Assets.Source.App.Builders;
using Assets.Source.App.Builders.Mission;
using Assets.Source.App.Builders.Spaceship;
using Assets.Source.App.Controllers.Mission.BossMission;
using Assets.Source.App.Controllers.Spaceship.Movement.Player;
using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Enums;

using UnityEngine;

namespace Assets.Source.App.Controllers.Mission {

  /// <summary>
  /// Classe responsável por armazenar informações da missão (nave escolhida, customizações)
  /// </summary>
  public class MissionStarter : MonoBehaviour {

    #region Campos

    /// <summary>
    /// Os controladores de cada missão.
    /// Inicializado pela Unity.
    /// </summary>
    public GameObject[] missionControllers;

    private Builder builder;

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Inicialização
    /// </summary>
    private void Start () {
      builder = new Builder();
      if (MissionData.missionName.Equals(Missions.Test)) {
        setUpTestScene();
      } else {
        setUpData();
        builder.set(newMissionController()).build(MissionData.missionController.gameObject);
      }
      builder.set(new PlayerBuilder()).build(PlayerData.spaceship);
      Destroy(this);
    }

    #endregion

    #region Meus Métodos

    private void setUpTestScene () {
      GameObject player = GameObject.FindGameObjectWithTag("Player Attacker");
      player.AddComponent<PlayerNormalMovementController>();
      PlayerData.spaceship = player;
    }

    private void setUpData () {
      PlayerData.spaceship = Instantiate(PlayerData.spaceship);
      int i = MissionData.missionName >= 0 ? (int) MissionData.missionName : 3;
      MissionData.missionController =
        Instantiate(missionControllers[i])
        .GetComponentInChildren<MissionController>();
    }

    private MissionBuilder newMissionController () {
      return
        MissionData.missionController is BossMissionController ?
          new BossMissionBuilder()
          :
          new MissionBuilder()
      ;
    }

    #endregion

  }
}
