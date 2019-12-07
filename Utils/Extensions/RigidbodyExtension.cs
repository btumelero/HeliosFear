using System;
using UnityEngine;

namespace Extensions {
  public static class RigidbodyExtension {

    public static bool isAt (this Rigidbody rigidbody, Vector3 position) {
      return rigidbody.transform.root.position.isAt(position);
    }

    public static void moveTowards (this Rigidbody rigidbody, Vector3 position, float speed) {
      rigidbody.transform.root.position = rigidbody.transform.root.position.moveTowards(
        position,
        speed
      );
    }

    public static bool rotationIsZero (this Rigidbody rigidbody) {
      return rigidbody.transform.root.rotation.isZero();
    }

    public static void rotateTowards (this Rigidbody rigidbody, Quaternion rotation, float speed) {
      rigidbody.transform.root.rotation = rigidbody.transform.root.rotation.rotateTowards(
        rotation,
        speed
      );
    }

    public static void setVelocity (this Rigidbody rigidBody, Vector3 direction, float velocity) {
      rigidBody.velocity = direction * velocity;
    }

    public static void fixRotation (this Rigidbody rigidBody) {
      rigidBody.transform.root.LookAt(rigidBody.velocity + rigidBody.transform.position);
    }

  }

}
