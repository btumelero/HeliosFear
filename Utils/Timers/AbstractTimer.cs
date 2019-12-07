using UnityEngine;

public abstract class AbstractTimer : MonoBehaviour {

  public float _baseTime;
  public float time;

  public float baseTime {
    get => _baseTime;
    set {
      _baseTime = value;
      time = value;
    }
  }

  public virtual void restart () {
    time = baseTime;
  }

  public bool timeIsUp () {
    return time <= 0;
  }

  public void setTimerEnabled (bool enabled) {
    this.enabled = enabled;
  }
}
