using UnityEngine;

/// <summary>
/// Timer que usa o método Update
/// </summary>
public class Timer : AbstractTimer {

  #region Métodos da Unity

  /// <summary>
  /// Desconta do timer a cada update
  /// </summary>
  protected virtual void Update () {
    if (time >= 0) {
      time -= Time.deltaTime;
    }
  }

  #endregion

}
