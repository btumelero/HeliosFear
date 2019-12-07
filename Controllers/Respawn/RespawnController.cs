using Delegates;
using Enums;
using UnityEngine;

public class RespawnController : MonoBehaviour {

  #region Variáveis

  public GameObject[] enemies;
  public RespawnZone respawnZone { get; set; }
  public RespawnType respawn { get; set; }
  public Pool pool { get; set; }
  public Timer respawnTimer { get; set; }

  public byte[] spawnChance;

  #endregion

  #region Getters e Setters

  public GameObject getPrefabOf (byte enemy) {
    return enemies[enemy];
  }

  public GameObject player {
    get => Mission.spaceship;
  }

  public byte getSpawnChance (Spaceships enemy) {
    return spawnChance[(byte) enemy];
  }

  protected byte getRandomEnemy () {
    int random = Random.Range(0, 100);
    return
      random < getSpawnChance(Spaceships.Normal) ? //0-x
        (byte) Spaceships.Normal
        :
      random >= 100 - getSpawnChance(Spaceships.Dodger) ? //z-100
        (byte) Spaceships.Dodger
        :
      random <= getSpawnChance(Spaceships.Normal) + getSpawnChance(Spaceships.Defender) ? //x-y
        (byte) Spaceships.Defender
        :
        (byte) Spaceships.Attacker
    ;
  }



  #endregion

  #region Métodos da Unity

  /**
   * Update is called once per frame
   */
  protected virtual void Update () {
    if (respawn != null) {
      respawn();
    }
  }

  #endregion

  #region Meus Métodos

  public void normalRespawn () {
    if (respawnTimer.timeIsUp()) {
      if (player != null) {
        respawnEnemy(respawnZone.top, getRandomEnemy());
        respawnTimer.restart();
      }
    }
  }

  public void specialRespawn () {
    if (respawnTimer.timeIsUp()) {
      if (player != null) {
        respawnEnemy(respawnZone.getRandomRespawnZone(), 4);
        respawnTimer.restart();
      }
    }
  }

  /**
   * Cria um inimigo em um local aleatório dentro da zona de reaparecimento com X% de chance pra cada tipo
   * 0-100 divido em três pontos (quatro partes): x, y, z. 0-x, x-y, y-z, z-100;
   */
  protected void respawnEnemy (BoxCollider boxCollider, byte enemy) {
    GameObject newEnemy =
      pool.enemyHasPool(enemy) == false ?
        spawnEnemy(4)
        :
      pool.enemyPoolIsEmpty(enemy) == false ?
        pool.retrieve(enemy)
        :
        spawnEnemy(enemy)
    ;
    newEnemy.transform.position = respawnZone.getRandomPointInBounds(boxCollider.bounds);
  }

  public GameObject spawnEnemy (byte enemy) {
    return Instantiate(getPrefabOf(enemy));
  }

  #endregion
}
