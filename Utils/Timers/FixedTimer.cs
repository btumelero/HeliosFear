using UnityEngine;

public class FixedTimer : AbstractTimer {

  /*
   * FixedUpdate is called every fixed frame-rate frame
   */
  protected virtual void FixedUpdate () {
    if (time >= 0) {
      time -= Time.fixedDeltaTime;
    }
  }
}
