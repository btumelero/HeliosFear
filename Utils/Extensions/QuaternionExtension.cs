using UnityEngine;

namespace Extensions {
  public static class QuaternionExtension {

    public static bool isZero (this Quaternion quaternion) {
      return quaternion.Equals(Quaternion.Euler(0, 0, 0));
    }

    public static Quaternion rotateTowards (this Quaternion quaternion, Quaternion rotation, float speed) {
      return Quaternion.RotateTowards(
        quaternion,
        rotation,
        speed * Time.fixedDeltaTime
      );
    }

  }

}
