namespace Assets.Source.App.Controllers.Bullets
{
  /// <summary>
  /// Classe responsável por gerenciar tiros especias do tipo beam
  /// </summary>
  public class BaseBeamController : SpecialBulletController {

    #region Métodos da Unity

    /// <summary>
    /// Inicializa o tempo do base do timer
    /// </summary>
    protected override void Start () {
      base.Start();
      autoDestroyTimer.baseTime = 0.05f;
    }

    #endregion

  }
}
