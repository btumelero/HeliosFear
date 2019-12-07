using Delegates;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controla o comportamento de ataque das naves do jogador
 */
public class PlayerAttackController : AttackController, IAttack {

  #region Variáveis

  public AttackType attack;

  /**
   * O som tocado quando o jogador atira
   * Inicializado pela interface da Unity
   */
  public AudioClip shootSound;

  /**
   * Responsável por tocar o som do tiro.
   * O '{ get; set; }' é para evitar que esta variável apareça na interface da Unity, 
   * já que ele é adicionado por código ao invés de 'arrastar e soltar' pela interface da Unity.
   */
  public AudioSource audioSource { get; set; }

  /**
   * Guardam o score e high score do jogador
   */
  private int _score, _highScore;

  /**
   * Referência do Text do score e highscore que aparecem na parte esquerda superior da tela
   */
  public Text scoreText { get; set; }
  public Text highScoreText { get; set; }

  #endregion

  #region Getters e Setters

  /**
   * Ao modificar o valor, atualiza o texto na tela também
   */
  public int score {
    get => _score;
    set {
      _score = value;
      scoreText.text = score.ToString();
      if (_score > _highScore) {
        highScore = _score;
      }
    }
  }

  /**
   * Ao modificar o valor, persiste o dado também
   */
  public int highScore {
    get => _highScore;
    set {
      _highScore = value;
      PlayerPrefs.SetInt(Enums.Player.HighScore.ToString(), highScore);
    }
  }

  #endregion

  #region Métodos da Unity

  /**
   * Update is called once per frame
   * 
   * Atira sempre que o jogador apertar o botão apropriado e continua atirando a cada X segundos se ele segurar apertado
   */
  protected override void Update () {
    if (attack != null) {
      attack();
    }
  }

  #endregion

  #region Meus Métodos

  public void normalAttack () {
    if (Input.GetButtonDown(Enums.Input.Fire1.ToString())) {
      fireActiveWeapons();
    } else if (Input.GetButton(Enums.Input.Fire1.ToString())) {
      if (shootTimer.timeIsUp()) {
        fireActiveWeapons();
        shootTimer.restart();
      }
    } else if (Input.GetButtonUp(Enums.Input.Fire1.ToString())) {
      shootTimer.restart();
    }
  }

  /**
   * Dispara tiros de todas as armas que estiverem ativas. Por padrão, as armas do jogador estão desativadas. 
   * Elas são posteriormente ativadas conforme a customização escolhida antes do início da missão.
   * Além disso, este método admite que o eixo y da arma esteja voltada para a direção em que o tiro deve ser disparado.
   * Além do que o método base faz, também toca o som do tiro
   */
  protected void fireActiveWeapons () {
    audioSource.PlayOneShot(shootSound);
    for (byte i = 0; i < weapons.Length; i++) {
      if (weapons[i].gameObject.activeSelf) {
        instantiateRotateAndMoveBullet(weapons[i]);
      }
    }
  }

  #endregion

}
