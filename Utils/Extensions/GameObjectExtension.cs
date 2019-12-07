using UnityEngine;

namespace Extensions {

  public static class GameObjectExtension {

    public static bool isAt (this GameObject gameObject, Vector3 position) {
      if (gameObject != null) {
        return gameObject.transform.root.position.isAt(position);
      }
      return false;
    }

    public static void moveTowards (this GameObject gameObject, Vector3 position, float speed) {
      gameObject.transform.root.position = gameObject.transform.root.position.moveTowards(
        position,
        speed
      );
    }

    public static bool rotationIsZero (this GameObject gameObject) {
      return gameObject.transform.root.rotation.isZero();
    }

    public static void rotateTowards (this GameObject gameObject, Quaternion rotation, float speed) {
      gameObject.transform.root.rotation = gameObject.transform.root.rotation.rotateTowards(
        rotation,
        speed
      );
    }

  }

}
