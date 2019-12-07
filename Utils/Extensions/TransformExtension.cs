using UnityEngine;

namespace Extensions {
  public static class TransformExtension {

    public static bool isAt (this Transform transform, Vector3 position) {
      return transform.root.position.isAt(position);
    }

    public static void moveTowards (this Transform transform, Vector3 position, float speed) {
      transform.root.position = transform.root.position.moveTowards(
        position,
        speed
      );
    }

    public static void rotateTowards (this Transform transform, Quaternion rotation, float speed) {
      transform.root.rotation = transform.root.rotation.rotateTowards(
        rotation,
        speed
      );
    }
  }

}
