using System.Collections;

namespace Assets.Source.App.Utils.Extensions {

  public static class IEnumeratorExtension {

    /// <summary>
    /// Retorna verdadeiro se são as mesmas coroutines
    /// </summary>
    /// 
    /// <param name="coroutine">
    /// Essa coroutine
    /// </param>
    /// 
    /// <param name="otherCoroutine">
    /// A coroutine com a qual a comparação deve ser feita
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se são as mesmas coroutines 
    /// </returns>
    public static bool? equals (this IEnumerator coroutine, IEnumerator otherCoroutine) {
      return coroutine?.ToString().Equals(otherCoroutine?.ToString());
    }

  }
}