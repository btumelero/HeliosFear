using UnityEngine;

/// <summary>
/// Timer que usa FixedUpdate
/// </summary>
public class FixedTimer : AbstractTimer {

  #region Métodos da Unity

  /// <summary>
  /// Desconta do timer a cada fixedUpdate
  /// </summary>
  protected virtual void FixedUpdate () {
    if (time >= 0) {
      time -= Time.fixedDeltaTime;
    }
  }

  #endregion
}
