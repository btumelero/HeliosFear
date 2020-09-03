using System;
using System.Linq;

using Assets.Source.App.Builders.Spaceship;
using Assets.Source.App.Controllers.Mission;
using Assets.Source.App.Controllers.Mission.BossMission;
using Assets.Source.App.Controllers.Respawn;
using Assets.Source.App.Controllers.Spaceship.Attack;
using Assets.Source.App.Controllers.Spaceship.Movement.Player;
using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Interfaces.Builders;

using UnityEngine;

/// <summary>
/// Contém todas as classes responsáveis por construir as missões do jogo
/// </summary>
namespace Assets.Source.App.Builders.Mission {

  /// <summary>
  /// Classe base responsável por construir as missões do jogo
  /// </summary>
  public class MissionBuilder : AbstractBuilder<MissionData>,
    IBuildable<EnemyData>,
    IBuildable<PlayerData>,
    IBuildable<MissionData> {

    #region Propriedades

    #region Auto-implementadas

    /// <summary>
    /// Os inimigos da missão
    /// </summary>
    protected Enemies enemies { get; private set; }

    /// <summary>
    /// O controlador de respawn da missão
    /// </summary>
    protected RespawnController respawnController { get; private set; }

    /// <summary>
    /// As zonas de respawn da missão
    /// </summary>
    protected RespawnZones respawnZones { get; private set; }

    #endregion

    #region Outras

    /// <summary>
    /// O controlador da missão
    /// </summary>
    public MissionController missionController =>
      MissionData.missionController
    ;

    /// <summary>
    /// A nave do jogador
    /// </summary>
    public GameObject player =>
      PlayerData.spaceship
    ;

    /// <summary>
    /// Os dados da missão
    /// </summary>
    public override MissionData data {
      get {
        MissionData.values.TryGetValue(MissionData.missionName, out MissionData missionData);
        return missionData;
      }
    }

    #endregion

    #endregion

    #region Getters

    /// <summary>
    /// Retorna uma ação com os passos necessário para construir a missão
    /// </summary>
    /// 
    /// <returns>
    /// Uma ação com os passos necessário para construir a missão
    /// </returns>
    public override Action getActions () {
      return () => {
        onBuild(objectToBuild);
        onBuild(data.enemyData);
        onBuild(data.playerData);
        onBuild(data);
      };
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Inicializa os campos do builder
    /// </summary>
    /// 
    /// <param name="mission">
    /// A missão com os componentes que o builder precisa
    /// </param>
    public override void onBuild (GameObject mission) {
      GameObject.FindWithTag("Tutorial").SetActive(false);
      enemies = mission.GetComponentInChildren<Enemies>();
      respawnController = mission.GetComponentInChildren<RespawnController>();
      respawnZones = mission.GetComponentInChildren<RespawnZones>();
    }

    /// <summary>
    /// Inicializações referentes aos inimigos
    /// </summary>
    /// 
    /// <param name="enemyData">
    /// Os dados dos inimigos da missão
    /// </param>
    public virtual void onBuild (EnemyData enemyData) {
      respawnController.respawnCoroutine = 
        respawnController.gameObject.AddComponent<CoroutineController>()
      ;
      respawnController.pooling = new Pooling();
      respawnController.spaceshipBuilder = new CommonEnemyBuilder();
      respawnController.builder = new Builder();
      respawnController.enemies = enemies;
      respawnController.enemies.spawnChance = enemyData.spawnChance;
      respawnController.respawnZones = respawnZones;
      respawnController.respawnZones.zones = respawnZones.gameObject
        .GetComponentsInChildren<BoxCollider>()
        .OrderBy(respawnZone => respawnZone.gameObject.name)
        .Reverse().ToArray()
      ;
      respawnController.respawnCoroutine.play(respawnController.normalRespawn());
    }

    /// <summary>
    /// Inicializações referentes ao jogador
    /// </summary>
    /// 
    /// <param name="playerData">
    /// Os dados do jogador
    /// </param>
    public virtual void onBuild (PlayerData playerData) {
      //missionController.inputs = new InputActions.Input();
      missionController.playerAttack = player.GetComponent<PlayerAttackController>();
      missionController.playerMovement =
        missionController is BossDefenderMissionController ?
          player.AddComponent<PlayerSpecialMovementController>()
          :
          player.AddComponent<PlayerNormalMovementController>()
      ;
    }

    /// <summary>
    /// Inicializações referentes à missão
    /// </summary>
    /// 
    /// <param name="missionData">
    /// Os dados da missão
    /// </param>
    public virtual void onBuild (MissionData missionData) {
      missionController.missionCoroutine =
        missionController.gameObject.AddComponent<CoroutineController>()
      ;
      missionController.missionCoroutine.play(missionController.onNormalMissionStart());
    }

  }

  #endregion

}

