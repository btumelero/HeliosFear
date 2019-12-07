public class DynamicTimer : Timer {

  #region Variáveis

  private float _actualTime;

  #endregion

  #region Getters e Setters

  public float actualTime {
    get => _actualTime;
    set {
      _actualTime = value;
      time = value;
    }
  }

  #endregion

  #region Meus Métodos

  public override void restart () {
    time = actualTime;
  }

  #endregion

}
