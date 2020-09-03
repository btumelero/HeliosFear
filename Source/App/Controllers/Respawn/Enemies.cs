using Assets.Source.App.Utils.Enums;

using UnityEngine;

namespace Assets.Source.App.Controllers.Respawn {

  public class Enemies : MonoBehaviour {

    #region Variáveis

    public GameObject[] enemyTypes;
    public byte[] spawnChance;

    #endregion

    #region Meus Métodos

    public GameObject getPrefabOf (byte enemy) {
      return enemyTypes[enemy];
    }

    private byte getSpawnChance (Spaceships enemy) {
      return spawnChance[(byte) enemy];
    }

    public GameObject getRandomEnemy () {
      int random = Random.Range(0, 100);
      return
        random < getSpawnChance(Spaceships.Normal) ?
          getPrefabOf((byte) Spaceships.Normal) //0-x
          :
        random >= 100 - getSpawnChance(Spaceships.Dodger) ?
          getPrefabOf((byte) Spaceships.Dodger) //z-100
          :
        random <= getSpawnChance(Spaceships.Normal) + getSpawnChance(Spaceships.Defender) ?
          getPrefabOf((byte) Spaceships.Defender) //x-y
          :
          getPrefabOf((byte) Spaceships.Attacker) //y-z
      ;
    }

    #endregion

  }
}
