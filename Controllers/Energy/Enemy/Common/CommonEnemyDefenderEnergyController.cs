using UnityEngine;

public class CommonEnemyDefenderEnergyController : EnemyEnergyController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Distribui de forma randomica a energia da nave, dando mais energia pro atributo principal dessa nave
   */
  protected override void Start () {
    base.Start();
    shieldMultiplier = Random.Range(60, 80);
    totalEnergy -= shieldMultiplier;
    speedMultiplier = Random.Range(40, 60);
    totalEnergy -= speedMultiplier;
    weaponMultiplier = totalEnergy;
  }

  #endregion

}
