/// <summary>
/// Contém todas as interfaces usadas em builders no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Builders {

  /// <summary>
  /// 
  /// </summary>
  /// 
  /// <typeparam name="T">
  /// 
  /// </typeparam>
  public interface IBuildable<T> where T : IData {

    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="Data">
    /// 
    /// </param>
    void onBuild (T Data);

  }

}