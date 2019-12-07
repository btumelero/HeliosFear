using UnityEngine;

namespace Extensions {
  public static class Vector3Extension {

    public static bool isAt (this Vector3 vector3, Vector3 position) {
      return Vector3.Distance(vector3, position) == 0;
    }

    public static Vector3 moveTowards (this Vector3 vector3, Vector3 position, float speed) {
      return Vector3.MoveTowards(
        vector3,
        position,
        speed * Time.fixedDeltaTime
      );
    }

  }

}
