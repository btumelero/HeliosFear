
using UnityEngine;

namespace Assets.Source.App.Data.Utils {

  public struct Rotation {

    public static readonly Quaternion
      zero = Quaternion.identity,
      facingScreen = Quaternion.Euler(90, 0, 0)
    ;

  }
}