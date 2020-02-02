using Delegates;

using Enums;

using Extensions;

using UnityEngine;

/// <summary>
/// Controla o respawn durante a missão
/// </summary>
public class RespawnController : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// Os inimigos presentes no jogo
  /// </summary>
  public GameObject[] enemies;

  /// <summary>
  /// As quatro zonas de respawn que ficam ao redor da tela
  /// </summary>
  public RespawnZones respawnZones { get; set; }

  /// <summary>
  /// Delegate usado para dar mais flexibilidade à forma como os inimigos irão dar respawn
  /// </summary>
  public RespawnType respawn { get; set; }

  /// <summary>
  /// Técnica de reaproveitamento de objetos para melhorar performance
  /// </summary>
  public Pool pool { get; set; }

  /// <summary>
  /// Timer usado para controlar o tempo entre respawns
  /// </summary>
  public Timer respawnTimer { get; set; }

  /// <summary>
  /// As chances dos inimigos reaparecerem
  /// </summary>
  public byte[] spawnChance;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Retorna a nave do jogador.
  /// Usado para checar se o jogador ainda está vivo.
  /// </summary>
  public GameObject player {
    get => Mission.spaceship;
  }

  /// <summary>
  /// Retorna o prefab do inimigo passado por parâmetro.
  /// Usado para instanciar inimigos
  /// </summary>
  /// 
  /// <param name="enemy">
  /// O inimigo cujo prefab deve ser retornado
  /// </param>
  /// 
  /// <returns>
  /// O prefab do inimigo
  /// </returns>
  public GameObject getPrefabOf (byte enemy) {
    return enemies[enemy];
  }

  /// <summary>
  /// Retorna a chance de respawn do inimigo passado por parâmetro
  /// </summary>
  /// 
  /// <param name="enemy">
  /// 
  /// </param>
  /// <returns></returns>
  public byte getSpawnChance (Spaceships enemy) {
    return spawnChance[(byte) enemy];
  }

  /// <summary>
  /// Retorna um inimigo aleatório com X% de chance pra cada tipo
  /// 0-100 divido em três pontos (quatro partes): x, y, z. 0-x, x-y, y-z, z-100;
  /// </summary>
  /// 
  /// <returns>
  /// Um inimigo aleatório
  /// </returns>
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
        : //y-z
        (byte) Spaceships.Attacker
    ;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Invocação do Delegate de respawn. 
  /// Usar o normalRespawn ou specialRespawn aqui.
  /// </summary>
  protected virtual void Update () {
    respawn?.Invoke();
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Respawn de inimigo na zona de respawn superior
  /// </summary>
  public void normalRespawn () {
    if (respawnTimer.timeIsUp()) {
      if (player != null) {
        respawnEnemy(respawnZones.top, getRandomEnemy());
        respawnTimer.restart();
      }
    }
  }

  /// <summary>
  /// Respawn de inimigo nas quatro zonas ao redor da tela 
  /// </summary>
  public void specialRespawn () {
    if (respawnTimer.timeIsUp()) {
      if (player != null) {
        respawnEnemy(respawnZones.getRandomRespawnZone(), 4);
        respawnTimer.restart();
      }
    }
  }

  /// <summary>
  /// Cria (ou recupera usando pool) um inimigo em um local aleatório dentro da zona de reaparecimento
  /// </summary>
  /// 
  /// <param name="respawnZone">
  /// A zona de respawn em que o inimigo deve aparecer
  /// </param>
  /// 
  /// <param name="enemy">
  /// O inimigo que deve aparecer
  /// </param>
  protected void respawnEnemy (BoxCollider respawnZone, byte enemy) {
    GameObject newEnemy =
      pool.enemyHasPool(enemy) == false ?
        spawnEnemy(4)
        :
      pool.enemyPoolIsEmpty(enemy) == false ?
        pool.retrieve(enemy)
        :
        spawnEnemy(enemy)
    ;
    newEnemy.transform.position = respawnZone.bounds.getRandomPointInBounds();
  }

  /// <summary>
  /// Instancia um inimigo do tipo passado por parâmetro.
  /// Usar o enum Spaceships aqui.
  /// </summary>
  /// 
  /// <param name="enemy">
  /// O inimigo que deve aparecer
  /// </param>
  /// 
  /// <returns>
  /// O inimigo instanciado
  /// </returns>
  public GameObject spawnEnemy (byte enemy) {
    return Instantiate(getPrefabOf(enemy));
  }

  #endregion

}
