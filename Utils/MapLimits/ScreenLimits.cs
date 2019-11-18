[System.Serializable]
public class ScreenLimits {

  #region Variáveis

  public int minimumX;
  public int maximumX;
  public int minimumY;
  public int maximumY;

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
