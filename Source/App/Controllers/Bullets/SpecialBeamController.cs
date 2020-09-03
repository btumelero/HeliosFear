using UnityEngine;

namespace Assets.Source.App.Controllers.Bullets
{
  /// <summary>
  /// Classe responsável por gerenciar tiros especias do tipo specialBeam
  /// </summary>
  public class SpecialBeamController : SpecialBulletController {

    #region Variáveis

    /// <summary>
    /// A largura mínima e máxima entre as quais o tiro vai variar
    /// </summary>
    public float min, max;

    /// <summary>
    /// Se tiro está aumentando ou diminuindo de largura
    /// </summary>
    public bool increase;

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Inicializações apenas
    /// </summary>
    protected override void Start () {
      base.Start();
      autoDestroyTimer.baseTime = 2;
      increase = true;
      min = 0.8f;
      max = 1.2f;
    }

    /// <summary>
    /// Aumenta e diminui a largura do tiro conforme o passar do tempo
    /// </summary>
    protected override void Update () {
      base.Update();
      transform.localScale = new Vector3(
        transform.localScale.x + Time.deltaTime * (increase ? 1 : -1),
        transform.localScale.y,
        transform.localScale.z < 1 ? transform.localScale.z + (Time.deltaTime * 3) : 1
      );
      if (transform.localScale.x >= max || transform.localScale.x <= min) {
        increase = !increase;
      }
    }

    #endregion

  }
}
