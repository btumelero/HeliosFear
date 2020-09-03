using Assets.Source.App.Data.Spaceship;

using UnityEngine;

/// <summary>
/// Contém classes responsáveis por impedir que objetos saiam da tela
/// </summary>
namespace Assets.Source.App.Utils.ScreenLimits {

  /// <summary>
  /// Classe responsável por demarcar os limites da tela
  /// </summary>
  public class ScreenLimits : MonoBehaviour {

    #region Propriedades

    public int minimumX =>
      SpaceshipData.values[transform.root.tag].movementData.minimumX
    ;

    public int maximumX =>
      SpaceshipData.values[transform.root.tag].movementData.maximumX
    ;

    public int minimumY =>
      SpaceshipData.values[transform.root.tag].movementData.minimumY
    ;

    public int maximumY =>
      SpaceshipData.values[transform.root.tag].movementData.maximumY
    ;

    #endregion

    #region Meus métodos

    /// <summary>
    /// Retorna verdadeiro se atingiu/saiu dos limites esquerdo ou direito da tela
    /// </summary>
    /// 
    /// <param name="position">
    /// Posição a ser checada
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se atingiu/saiu dos limites
    /// </returns>
    public bool xEdgeReached () {
      return transform.position.x >= maximumX || transform.position.x <= minimumX;
    }

    /// <summary>
    /// Retorna verdadeiro se atingiu/saiu dos limites superior ou inferior da tela
    /// </summary>
    /// 
    /// <param name="position">
    /// Posição a ser checada
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se atingiu/saiu dos limites
    /// </returns>
    public bool yEdgeReached () {
      return transform.position.y >= maximumY || transform.position.y <= minimumY;
    }

    #endregion

  }

}