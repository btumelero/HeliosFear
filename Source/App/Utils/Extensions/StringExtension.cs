using System;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Assets.Source.App.Utils.Extensions {

  /// <summary>
  /// Extensões de strings
  /// </summary>
  public static class StringExtension {

    /// <summary>
    /// Converte uma string em um enum do tipo T
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// O tipo de enum em que a string deve ser convertida
    /// </typeparam>
    /// 
    /// <param name="str">
    /// A string a ser convertida
    /// </param>
    /// 
    /// <returns>
    /// Um enum do tipo T
    /// </returns>
    public static T toEnum<T> (this string str) where T : Enum {
      return (T) Enum.Parse(typeof(T), str);
    }

  }
}