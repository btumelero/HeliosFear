public abstract class SpecialBulletController : BulletController {

  #region Variáveis

  public Timer autoDestroyTimer { get; set; }

  #endregion

  #region Métodos da Unity

  protected virtual void Start () {
    autoDestroyTimer = gameObject.AddComponent<Timer>();
  }

  protected virtual void Update () {
    if (autoDestroyTimer.timeIsUp()) {
      Destroy(gameObject);
    }
  }

  #endregion

}
