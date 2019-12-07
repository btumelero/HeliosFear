using System.Linq;
using UnityEngine;

public abstract class MissionConstructor : MonoBehaviour {

  #region Variáveis

  protected MissionController _missionController { get; private set; }
  protected RespawnController _respawnController { get; private set; }
  protected RespawnZone respawnZone { get; private set; }

  #endregion

  #region Getters e Setters

  public MissionController missionController {
    get => _missionController;
  }

  public GameObject player {
    get => Mission.spaceship;
    set => Mission.spaceship = value;
  }

  #endregion

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   */
  protected virtual void Start () {
    GameObject.FindWithTag("Tutorial").SetActive(false);
    setUpConstructor();
    setUpMissionController();
    setUpRespawnController();
    setUpRespawnZone();
  }

  #endregion

  #region Meus Métodos

  protected virtual void setUpConstructor () {
    respawnZone = GetComponentInChildren<RespawnZone>();
    _missionController = GetComponent<MissionController>();
    _respawnController = GetComponentInChildren<RespawnController>();
  }

  protected virtual void setUpMissionController () {
    _missionController.player = Instantiate(Mission.spaceship);
    _missionController._playerMovementController = player.GetComponent<PlayerMovementController>();
    _missionController._playerAttackController = player.GetComponent<PlayerAttackController>();
    _missionController.missionStage = _missionController.preNormalMission;
  }

  protected virtual void setUpRespawnController () {
    _respawnController.spawnChance = new byte[4];
    _respawnController.respawnZone = respawnZone;
    _respawnController.respawnTimer = _respawnController.gameObject.AddComponent<Timer>();
    _respawnController.pool = GetComponentInChildren<Pool>();
    _respawnController.respawn = _respawnController.normalRespawn;
  }

  protected virtual void setUpRespawnZone () {
    respawnZone._zones = gameObject
      .GetComponentsInChildren<BoxCollider>()
      .OrderBy(bo => bo.gameObject.name)
      .Reverse().ToArray()
    ;
  }

  #endregion

}
