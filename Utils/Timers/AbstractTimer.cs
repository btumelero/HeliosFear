using UnityEngine;

public abstract class AbstractTimer : MonoBehaviour {

  private float _baseTime;
  protected float time;

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
}
