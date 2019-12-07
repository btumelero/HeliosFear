using UnityEngine;

public class BeamCollisionController : BulletCollisionController {

  #region Variáveis

  private float originalShootPower;

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    originalShootPower = bulletController.shootPower;
  }

  private void OnTriggerStay (Collider other) {
    bulletController.shootPower = originalShootPower * (Time.deltaTime * 2);
    OnTriggerEnter(other);
  }

  private void OnTriggerExit (Collider other) {
    bulletController.shootPower = originalShootPower;
  }

  #endregion

}
