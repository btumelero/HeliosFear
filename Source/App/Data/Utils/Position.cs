using UnityEngine;

namespace Assets.Source.App.Data.Utils {

  public struct Position {

    #region Constantes

    public static readonly Vector3
      offscreenTop = new Vector3(0, 65),
      poolingPosition = new Vector3(60, 60),
      screenBottom = new Vector3(0, -30),
      screenCenter = new Vector3(0, 0),
      screenTop = new Vector3(0, 22)
    ;

    #endregion

  }
}