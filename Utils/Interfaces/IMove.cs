/// <summary>
/// Contém as interfaces usadas no projeto
/// </summary>
namespace Interfaces {

  /// <summary>
  /// Contém as interfaces relacionadas ao movimento de objetos no projeto
  /// </summary>
  namespace Movements {

    /// <summary>
    /// Interface iplementada pelos objetos que se movem
    /// </summary>
    public interface IMove {

      /// <summary>
      /// A velocidade base do objeto
      /// </summary>
      float baseSpeed { get; }

      /// <summary>
      /// A velocidade real/atual do objeto 
      /// (após sofrer modificações dos multiplicadores da energia da nave, por exemplo)
      /// </summary>
      float actualSpeed { get; }

    }

  }

}
