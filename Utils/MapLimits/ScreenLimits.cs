[System.Serializable]
public class ScreenLimits {

  #region Variáveis

  public int minimumX { get; set; }
  public int maximumX { get; set; }
  public int minimumY { get; set; }
  public int maximumY { get; set; }

  #endregion

  #region Meus métodos

  /*
   * Retorna verdadeiro se atingiu/saiu dos limites esquerdo ou direito da tela
   */
  public bool xEdgeReached (float position) {
    return position >= maximumX || position <= minimumX;
  }

  /*
   * Retorna verdadeiro se atingiu/saiu dos limites superior ou inferior da tela
   */
  public bool yEdgeReached (float position) {
    return position >= maximumY || position <= minimumY;
  }

  #endregion

}
