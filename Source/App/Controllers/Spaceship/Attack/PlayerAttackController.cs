using System.Collections;

using Assets.Source.App.Utils.Enums;
using Assets.Source.Experimental;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.App.Controllers.Spaceship.Attack {

  /// <summary>
  /// Controla o comportamento de ataque das naves do jogador
  /// </summary>
  public class PlayerAttackController : AttackController {

    #region Campos

    /// <summary>
    /// O som tocado quando o jogador atira.
    /// </summary>
    public AudioClip shootSound;

    /// <summary>
    /// Responsável por tocar o som do tiro.
    /// </summary>
    [HideInInspector] public AudioSource audioSource;

    /// <summary>
    /// Referência do Text do score que aparece na parte esquerda superior da tela
    /// </summary>
    [HideInInspector] public Text scoreText;

    /// <summary>
    /// Referência do Text do highscore que aparece na parte esquerda superior da tela
    /// </summary>
    [HideInInspector] public Text highScoreText;

    /// <summary>
    /// Guardam o score e high score do jogador
    /// </summary>
    public FieldWithAction<int> score, highScore;

    #endregion

    #region Propriedades

    /// <summary>
    /// Ao modificar o valor, atualiza o texto na tela também
    /// </summary>
    public void onScoreValueChange () {
      scoreText.text = score.ToString();
      if (score.Value > highScore.Value) {
        highScore.Value = score.Value;
      }
    }

    /// <summary>
    /// Ao modificar o valor, persiste o dado também
    /// </summary>
    public void onHighScoreValueChange () {
      PlayerPrefs.SetInt(Tags.HighScore.ToString(), highScore.Value);
    }

    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// Atira a cada X segundos quando o jogador apertar/segurar o botão apropriado
    /// </summary>
    public override IEnumerator normalAttack () {
      while (true) {
        yield return new WaitUntil(
          () => Input.GetButtonDown(Inputs.Fire1.ToString()) || Input.GetButton(Inputs.Fire1.ToString())
        );
        fireActiveWeapons();
        yield return new WaitForSeconds(shootTimer);
      }
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Dispara tiros de todas as armas que estiverem ativas e toca o som do tiro. 
    /// Por padrão, as armas do jogador estão desativadas.
    /// Elas são posteriormente ativadas conforme a customização escolhida antes do início da missão.
    /// Além disso, este método admite que o eixo y da arma esteja voltada para a direção 
    /// em que o tiro deve ser disparado.
    /// </summary>
    protected void fireActiveWeapons () {
      audioSource.PlayOneShot(shootSound);
      for (byte i = 0; i < weapons.Length; i++) {
        if (weapons[i].gameObject.activeSelf) {
          shoot(weapons[i]);
        }
      }
    }

    #endregion

  }
}
