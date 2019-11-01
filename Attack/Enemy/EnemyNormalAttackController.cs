﻿using UnityEngine;

public class EnemyNormalAttackController : EnemyAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade e a potência base do tiro e randomiza o tempo entre disparos
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime= Random.Range(2, 5);
    shootVelocity = 30;
    baseShootPower = 3;// 6/2
  }

  #endregion

  #region Meus Métodos

  /*
   * Esse tipo de nave atira dois tiros para baixo
   * Retorna verdadeiro se atirou
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);
    instantiateAndMoveBullet(shootPositions[1], Vector3.down);
  }
  
  #endregion

}
