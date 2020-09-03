using UnityEngine;

namespace Assets.Source.App.Utils.Extensions {

  public static class FloatExtension {

    /// <summary>
    /// Retorna um valor aleatório dentro do alcance específicado
    /// </summary>
    /// 
    /// <param name="value">
    /// O valor base
    /// </param>
    /// 
    /// <param name="range">
    /// O valor que define o alcance para mais e para menos
    /// </param>
    /// 
    /// <returns>
    /// Um valor aleatório dentro do alcance específicado
    /// </returns>
    public static float randomInRange (this float value, float range) {
      return Random.Range(value - range, value + range);
    }
  }
}