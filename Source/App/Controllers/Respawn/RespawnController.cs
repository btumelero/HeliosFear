using System.Collections;

using Assets.Source.App.Builders;
using Assets.Source.App.Builders.Spaceship;
using Assets.Source.App.Data.Mission;

using UnityEngine;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Data.Utils;

namespace Assets.Source.App.Controllers.Respawn {

  public class RespawnController : MonoBehaviour {

    #region Campos
    [HideInInspector] public CoroutineController respawnCoroutine;
    [HideInInspector] public Enemies enemies;
    [HideInInspector] public RespawnZones respawnZones;
    public Pooling pooling;
    public SpaceshipBuilder spaceshipBuilder;
    public Builder builder;

    private GameObject newEnemy;

    #endregion

    #region Meus Métodos

    private GameObject spawnEnemy (GameObject enemy, Vector3 position) {
      return Instantiate(enemy, position, Rotation.zero);
    }

    private void respawnEnemy (BoxCollider respawnZone, GameObject enemy) {
      Vector3 position = respawnZone.getRandomPointInside();
      if ((newEnemy = pooling.retrieve(enemy, position)) == null) {
        newEnemy = spawnEnemy(enemy, position);
      }
    }

    #endregion

    #region Minhas Rotinas

    public IEnumerator normalRespawn () {
      if (MissionData.missionName != Missions.Tutorial) {
        while (PlayerData.spaceship != null) {
          yield return new WaitForSeconds(
            MissionData.values[MissionData.missionName].enemyData.normalRespawnTimer
          );
          respawnEnemy(respawnZones.top, enemies.getRandomEnemy());
          builder.set(spaceshipBuilder).build(newEnemy);
        }
      }
    }

    public IEnumerator specialRespawn () {
      while (PlayerData.spaceship != null) {
        yield return new WaitForSeconds(
          MissionData.values[MissionData.missionName].enemyData.specialRespawnTimer
        );
        respawnEnemy(respawnZones.getRandomRespawnZone(), enemies.getPrefabOf(4));
      }
    }

    #endregion

  }
}
