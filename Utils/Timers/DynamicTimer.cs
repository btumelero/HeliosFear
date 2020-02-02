/// <summary>
/// Timer que permite tempos variáveis
/// </summary>
public class DynamicTimer : Timer {

  #region Variáveis

  /// <summary>
  /// O tempo real/atual do timer (após sofrer modificações de multiplicadores, por exemplo)
  /// </summary>
  private float _actualTime;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// O tempo real/atual do timer (após sofrer modificações de multiplicadores, por exemplo)
  /// Reseta o tempo ao settar um novo tempo atual
  /// </summary>
  public float actualTime {
    get => _actualTime;
    set {
      _actualTime = value;
      time = value;
    }
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Reseta o timer
  /// </summary>
  public override void restart () {
    time = actualTime;
  }

  #endregion

}
