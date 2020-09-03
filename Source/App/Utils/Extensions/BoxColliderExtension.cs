using UnityEngine;

public static class BoxColliderExtension {
  
  /// <summary>
  /// Retorna um ponto aleatório dentro dos limites de uma zona de respawn.
  /// </summary>
  /// 
  /// <param name="boxCollider">
  /// O objeto que representa os limites
  /// </param>
  /// 
  /// <returns>
  /// Um vetor com um ponto aleatório dentro dos limites.
  /// </returns>
  public static Vector3 getRandomPointInside (this BoxCollider boxCollider) {
    return new Vector3(
        Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
        Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y),
        0
    );
  }
}
