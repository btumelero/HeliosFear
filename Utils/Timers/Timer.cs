using UnityEngine;

public class Timer : AbstractTimer {

  /*
   * Update is called once per frame
   */
  protected virtual void Update () {
    if (time >= 0) {
      time -= Time.deltaTime;
    }
  }

}
