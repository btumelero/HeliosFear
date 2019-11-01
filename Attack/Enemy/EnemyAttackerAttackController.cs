using UnityEngine;

public class EnemyAttackerAttackController : EnemyAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade e a potência base do tiro e randomiza o tempo entre disparos
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = Random.Range(1, 4);
    shootVelocity = 20;
    baseShootPower = 8;
  }

  #endregion

  #region Meus Métodos

  /*
   * Esse tipo de nave atira três tiros que se espalham
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);//baixo
    instantiateAndMoveBullet(shootPositions[1], new Vector3(-0.5f, -1));//baixo+esquerda
    instantiateAndMoveBullet(shootPositions[2], new Vector3(0.5f, -1));//baixo+direita
  }

  #endregion
}
