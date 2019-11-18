using UnityEngine;
using UnityEngine.UI;

public class PlayerConstructor : SpaceshipController {

  #region Vari�veis

  private int _score, _highscore;

  private Text scoreText, highscoreText;

  #endregion

  #region Getters e Setters

  public int score {
    get => _score;
    set {
      _score = value;
      scoreText.text = score.ToString();
      if (_score > _highscore) {
        highscore = _score;
      }
    }
  }

  public int highscore {
    get => _highscore;
    set {
      _highscore = value;
      PlayerPrefs.SetInt("HighScore", highscore);
    }
  }

  #endregion

  #region M�todos da Unity

  /* 
   * Start is called before the first frame update
   * Inicializa o highscore do jogador
   */
  protected override void Start () {
    scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    highscoreText = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>();
    setUpHighScore();
  }

  /*
   * Acaba o jogo caso o player tenha morrido:
   */
  private void OnDestroy () {
    GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
    if (canvas != null) {
      GameController gameController = canvas.GetComponent<GameController>();
      if (gameController != null) {
        gameController.enabled = false;
      }
    }
  }

  #endregion

  #region Meus m�todos

  /*
   * Provis�rio: salva nas prefer�ncias do jogador o highscore dele e depois atualiza o texto na tela
   */
  private void setUpHighScore () {
    if (PlayerPrefs.HasKey("HighScore") == false) {
      PlayerPrefs.SetInt("HighScore", 0);
    }
    highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
  }

  #endregion

}