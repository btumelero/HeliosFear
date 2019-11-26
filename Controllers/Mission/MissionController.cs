using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MissionController : MonoBehaviour {

  #region Variáveis

  public Timer timer { get; set; }
  public ScreenLimits respawnZone;
  public GameObject[] enemies;

  public byte[] spawnChance;
  public bool gameOver;

  #endregion

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   * Cria a nave do jogador, adiciona o timer pra dar respawn nos inimigos e 
   * setta os limites da área onde os inimigos vão ser criados
   */
  protected virtual void Start () {
    Instantiate(SpaceshipSelectionController.spaceship);
    timer = gameObject.AddComponent<Timer>();
    gameOver = false;
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
      if (gameOver) {
        SceneManager.LoadScene(Enums.Scenes.MainMenu.ToString());
      } else {
        spawnEnemy();
        timer.restart();
      }
    }
  }

  #endregion

  #region Meus Métodos

  /**
   * Cria um inimigo em um local aleatório dentro da zona de reaparecimento com X% de chance pra cada tipo
   * 0-100 divido em três pontos (quatro partes): x, y, z. 0-x, x-y, y-z, z-100;
   */
  protected virtual void spawnEnemy () {
    int random = Random.Range(0, 100);
    GameObject enemy =
      random < spawnChance[(byte) Enums.Spaceships.Normal] ? //0-x
        enemies[(byte) Enums.Spaceships.Normal]
        :
      random >= 100 - spawnChance[(byte) Enums.Spaceships.Dodger] ? //z-100
        enemies[(byte) Enums.Spaceships.Dodger]
        :
      random <= spawnChance[(byte) Enums.Spaceships.Normal] + spawnChance[(byte) Enums.Spaceships.Defender] ? //x-y
        enemies[(byte) Enums.Spaceships.Defender]
        :
        enemies[(byte) Enums.Spaceships.Attacker] //y-z
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

  #endregion

}
