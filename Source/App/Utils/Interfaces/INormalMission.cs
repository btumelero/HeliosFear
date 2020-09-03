using System.Collections;
/// <summary>
/// Contém as interfaces usadas em missões no projeto
/// </summary>
namespace Assets.Source.App.Utils.Interfaces.Missions {

  /// <summary>
  /// Interface implementada pelas missões normais
  /// </summary>
  public interface INormalMission {

    /// <summary>
    /// Estágio pré-missão
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    IEnumerator onNormalMissionStart ();

    /// <summary>
    /// Estágio missão
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    IEnumerator onNormalMission ();

    /// <summary>
    /// Estágio pós-missão
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    IEnumerator onNormalMissionEnd ();

    /// <summary>
    /// Durante todos os estágios
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    IEnumerator onMission (IEnumerator nextStage);

  }

}