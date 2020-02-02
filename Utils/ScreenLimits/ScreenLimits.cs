/// <summary>
/// Classe responsável por demarcar os limites da tela
/// </summary>
[System.Serializable]
public class ScreenLimits {

  #region Variáveis

  public int minimumX;
  public int maximumX;
  public int minimumY;
  public int maximumY;

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
  public bool xEdgeReached (float position) {
    return position >= maximumX || position <= minimumX;
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
  public bool yEdgeReached (float position) {
    return position >= maximumY || position <= minimumY;
  }

  #endregion

}
