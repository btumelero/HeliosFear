using UnityEngine;

public class GameController : MonoBehaviour {

  public ScreenLimits respawnZone;
  public GameObject[] enemies;
  public Timer timer;
  private enum enemyType : byte { ATTACKER, DEFENDER, DODGER, NORMAL };

  /*
   * Start is called before the first frame update
   * Inicializar o tempo que vai levar pra um novo inimo aparecer
   */
  private void Start () {
    Instantiate(SpaceshipSelectionController.spaceship, new Vector3(0, -12, 0), Quaternion.Euler(0, 0, 0));
    timer = gameObject.AddComponent<Timer>();
    respawnZone.minimumX = -21;
    respawnZone.maximumX = 20;
    respawnZone.minimumY = 25;
    respawnZone.maximumY = 29;
    timer.baseTime = 1.25f;
  }

  /*
   * Update is called once per frame
   * Desconta do timer e faz um novo inimigo aparecer caso ele tenha esgotado, reiniciando o timer depois
   */
  private void Update () {
    if (timer.timeIsUp()) {
      spawnEnemy();
      timer.restart();
    }
  }

  /*
   * Cria um inimigo em um local aleatório dentro da zona de reaparecimento
   * 40% de chance pro tipo normal, 30% pro dodger e 15% pro attacker e defender
   */
  private void spawnEnemy () {
    int random = Random.Range(0, 100);
    GameObject enemy =
      random < 40 ?
        enemies[(byte) enemyType.NORMAL]
        :
      random >= 70 ?
        enemies[(byte) enemyType.DODGER]
        :
      random >= 40 && random <= 54 ?
        enemies[(byte) enemyType.DEFENDER]
        :
        enemies[(byte) enemyType.ATTACKER]
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
