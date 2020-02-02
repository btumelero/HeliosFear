using UnityEngine;

/// <summary>
/// Classe timer base
/// </summary>
public abstract class AbstractTimer : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// O tempo base do timer
  /// </summary>
  public float _baseTime;

  /// <summary>
  /// o tempo do timer
  /// </summary>
  public float time;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// O tempo base do timer.
  /// Reseta o tempo ao settar um novo tempo base
  /// </summary>
  public float baseTime {
    get => _baseTime;
    set {
      _baseTime = value;
      time = value;
    }
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Reinicia o timer
  /// </summary>
  public virtual void restart () {
    time = baseTime;
  }

  /// <summary>
  /// Retorna verdadeiro se o tempo acabou
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o tempo acabou
  /// </returns>
  public bool timeIsUp () {
    return time <= 0;
  }

  #endregion
}
