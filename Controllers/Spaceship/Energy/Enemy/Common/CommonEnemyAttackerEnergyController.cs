using UnityEngine;

public class CommonEnemyAttackerEnergyController : EnemyEnergyController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Distribui de forma randomica a energia da nave, dando mais energia pro atributo principal dessa nave
   */
  protected override void Start () {
    base.Start();
    weaponMultiplier = Random.Range(60, 80);
    totalEnergy -= weaponMultiplier;
    speedMultiplier = Random.Range(40, 60);
    totalEnergy -= speedMultiplier;
    shieldMultiplier = totalEnergy;
  }

  #endregion

}
