using Delegates;

using Interfaces;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla o comportamento de ataque das naves do jogador
/// </summary>
public class PlayerAttackController : AttackController {

  #region Variáveis

  /// <summary>
  /// O som tocado quando o jogador atira. Inicializado pela interface da Unity
  /// </summary>
  public AudioClip shootSound;

  /// <summary>
  /// Responsável por tocar o som do tiro.
  /// O '{ get; set; }' é para evitar que esta variável apareça na interface da Unity, 
  /// já que ele é adicionado por código ao invés de 'arrastar e soltar' pela interface da Unity.
  /// </summary>
  public AudioSource audioSource { get; set; }

  /// <summary>
  /// Guardam o score e high score do jogador
  /// </summary>
  private int _score, _highScore;

  /// <summary>
  /// Referência do Text do score que aparece na parte esquerda superior da tela
  /// </summary>
  public Text scoreText { get; set; }

  /// <summary>
  /// Referência do Text do highscore que aparece na parte esquerda superior da tela
  /// </summary>
  public Text highScoreText { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Ao modificar o valor, atualiza o texto na tela também
  /// </summary>
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

  /// <summary>
  /// Ao modificar o valor, persiste o dado também
  /// </summary>
  public int highScore {
    get => _highScore;
    set {
      _highScore = value;
      PlayerPrefs.SetInt(Enums.Player.HighScore.ToString(), highScore);
    }
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Atira sempre que o jogador apertar o botão apropriado e continua atirando a cada X segundos se ele segurar apertado
  /// </summary>
  public override void normalAttack () {
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

  /// <summary>
  /// Dispara tiros de todas as armas que estiverem ativas e toca o som do tiro. 
  /// Por padrão, as armas do jogador estão desativadas.
  /// Elas são posteriormente ativadas conforme a customização escolhida antes do início da missão.
  /// Além disso, este método admite que o eixo y da arma esteja voltada para a direção em que o tiro deve ser disparado.
  /// </summary>
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
