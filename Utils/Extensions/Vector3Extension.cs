using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da classe Vector3
  /// </summary>
  public static class Vector3Extension {

    /// <summary>
    /// Retorna verdadeiro esse objeto está na posição passada por parâmetro
    /// </summary>
    /// 
    /// <param name="vector3">
    /// A posição desse objeto
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser checada
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se está na posição
    /// </returns>
    public static bool isAt (this Vector3 vector3, Vector3 position) {
      return Vector3.Distance(vector3, position) == 0;
    }

    /// <summary>
    /// Move o objeto para a posição passada por parâmetro na velocidade indicada
    /// </summary>
    /// 
    /// <param name="vector3">
    /// A posição desse objeto
    /// </param>
    /// 
    /// <param name="position">
    /// A posição a ser atingida
    /// </param>
    /// 
    /// <param name="speed">
    /// A velocidade de movimentação
    /// </param>
    /// 
    /// <returns>
    /// Um vetor com a posição atual
    /// </returns>
    public static Vector3 moveTowards (this Vector3 vector3, Vector3 position, float speed) {
      return Vector3.MoveTowards(
        vector3,
        position,
        speed * Time.fixedDeltaTime
      );
    }

  }

}
