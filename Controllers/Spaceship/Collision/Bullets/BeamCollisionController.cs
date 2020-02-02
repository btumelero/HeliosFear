using UnityEngine;

/// <summary>
/// Classe responsável por controlar colisões com tiros especiais
/// </summary>
public class BeamCollisionController : BulletCollisionController {

  #region Variáveis

  /// <summary>
  /// O dano original desse tiro especial
  /// </summary>
  private float originalShootPower;

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicialização apenas
  /// </summary>
  protected override void Start () {
    base.Start();
    originalShootPower = bulletController.shootPower;
  }

  /// <summary>
  /// Dá um dano menor ao longo do tempo enquanto a nave inimiga continuar sendo atingida por esse tiro especial
  /// </summary>
  /// 
  /// <param name="other">
  /// O objeto que colidiu com o objeto que tem esse script
  /// </param>
  private void OnTriggerStay (Collider other) {
    bulletController.shootPower = originalShootPower * (Time.deltaTime * 2);
    OnTriggerEnter(other);
  }

  /// <summary>
  /// Reseta o dano do tiro especial quando a nave inimiga deixar de ser atingida pelo tiro
  /// </summary>
  /// 
  /// <param name="other">
  /// O objeto que colidiu com o objeto que tem esse script
  /// </param>
  private void OnTriggerExit (Collider other) {
    bulletController.shootPower = originalShootPower;
  }

  #endregion

}
