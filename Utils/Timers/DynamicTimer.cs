public class DynamicTimer : Timer {

  private float _actualTime;

  public float actualTime {
    get => _actualTime;
    set {
      _actualTime = value;
      time = value;
    }
  }

  public override void restart () {
    time = actualTime;
  }
}
