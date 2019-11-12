using UnityEngine;

public class BossEnemyDodgerEnergyController : EnemyEnergyController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Distribui de forma randomica a energia da nave, dando mais energia pro atributo principal dessa nave
   */
  protected override void Start () {
    base.Start();
    speedMultiplier = Random.Range(60, 80);
    totalEnergy -= speedMultiplier;
    shieldMultiplier = totalEnergy / 2;
    weaponMultiplier = totalEnergy / 2;
  }

  #endregion

}
