using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da classe Bounds
  /// </summary>
  public static class BoundsExtension {

    /// <summary>
    /// Retorna um ponto aleatório dentro dos limites de uma zona de respawn.
    /// </summary>
    /// 
    /// <param name="bounds">
    /// O objeto que representa os limites de um Collider
    /// </param>
    /// 
    /// <returns>
    /// Um vetor com um ponto aleatório dentro dos limites
    /// </returns>
    public static Vector3 getRandomPointInBounds (this Bounds bounds) {
      return new Vector3(
          Random.Range(bounds.min.x, bounds.max.x),
          Random.Range(bounds.min.y, bounds.max.y),
          0
      );
    }

  }

}