using UnityEngine;

public abstract class MissionController : MonoBehaviour {

  public ScreenLimits respawnZone;
  public GameObject[] enemies;
  public Timer timer { get; set; }
  protected byte[] spawnChance;
  protected enum enemyType : byte { ATTACKER, DEFENDER, DODGER, NORMAL };

  /**
   * Start is called before the first frame update
   * Cria a nave do jogador, adiciona o timer pra dar respawn nos inimigos e 
   * setta os limites da área onde os inimigos vão ser criados
   */
  protected virtual void Start () {
    Instantiate(SpaceshipSelectionController.spaceship, new Vector3(0, -20, 0), Quaternion.Euler(0, 0, 0));
    timer = gameObject.AddComponent<Timer>();
    respawnZone.minimumX = -27;
    respawnZone.maximumX = 27;
    respawnZone.minimumY = 44;
    respawnZone.maximumY = 46;
    spawnChance = new byte[4];
  }


  /**
   * Update is called once per frame
   * Desconta do timer e faz um novo inimigo aparecer caso ele tenha esgotado, reiniciando o timer depois
   */
  protected virtual void Update () {
    if (timer.timeIsUp()) {
      spawnEnemy();
      timer.restart();
    }
  }

  /**
   * Cria um inimigo em um local aleatório dentro da zona de reaparecimento com X% de chance pra cada tipo
   * 0-100 divido em três pontos (quatro partes): x, y, z. 0-x, x-y, y-z, z-100;
   */
  protected virtual void spawnEnemy () {
    int random = Random.Range(0, 100);
    GameObject enemy =
      random < spawnChance[(byte) enemyType.NORMAL] ? //0-x
        enemies[(byte) enemyType.NORMAL]
        :
      random >= 100 - spawnChance[(byte) enemyType.DODGER] ? //z-100
        enemies[(byte) enemyType.DODGER]
        :
      random <= spawnChance[(byte) enemyType.NORMAL] + spawnChance[(byte) enemyType.DEFENDER] ? //x-y
        enemies[(byte) enemyType.DEFENDER]
        :
        enemies[(byte) enemyType.ATTACKER] //y-z
    ;
    Instantiate(
      enemy,
      new Vector3(
        Random.Range(respawnZone.minimumX, respawnZone.maximumX + 1),
        Random.Range(respawnZone.minimumY, respawnZone.maximumY + 1),
        0
      ),
      enemy.transform.rotation
    );
  }

}
