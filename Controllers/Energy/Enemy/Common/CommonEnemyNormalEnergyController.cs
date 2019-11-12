using UnityEngine;

public class CommonEnemyNormalEnergyController : EnemyEnergyController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Distribui de forma randomica a energia da nave, dando mais energia pro atributo principal dessa nave
   */
  protected override void Start () {
    base.Start();
    speedMultiplier = Random.Range(40, 60);
    totalEnergy -= speedMultiplier;
    shieldMultiplier = Random.Range(40, 60);
    totalEnergy -= shieldMultiplier;
    weaponMultiplier = totalEnergy;
  }

  #endregion

}
