/// <summary>
/// Classe responsável por gerenciar tiros especiais
/// </summary>
public abstract class SpecialBulletController : BulletController {

  #region Variáveis

  /// <summary>
  /// Timer para controlar a duração do tiro na tela
  /// </summary>
  public Timer autoDestroyTimer { get; set; }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicializa o Timer
  /// </summary>
  protected virtual void Start () {
    autoDestroyTimer = gameObject.AddComponent<Timer>();
  }

  /// <summary>
  /// Destrói o tiro ao esgotar o tempo do timer
  /// </summary>
  protected virtual void Update () {
    if (autoDestroyTimer.timeIsUp()) {
      Destroy(gameObject);
    }
  }

  #endregion

}
