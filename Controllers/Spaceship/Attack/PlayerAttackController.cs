﻿using UnityEngine;

public abstract class PlayerAttackController : AttackController {

  #region Variáveis

  public AudioClip shootSound;
  private AudioSource audioSource;
  public int bulletsPerFire { get; set; }

  #endregion

  #region Métodos da Unity

  /*
  * Atira sempre que o jogador apertar o botão apropriado e continua atirando a cada X segundos se ele segurar apertado
  */
  protected override void Update () {
    if (Input.GetButtonDown("Fire1")) {
      shootAppropriateNumberOfShoots();
    } else if (Input.GetButton("Fire1")) {
      if (shootTimer.timeIsUp()) {
        shootAppropriateNumberOfShoots();
        shootTimer.restart();
      }
    } else if (Input.GetButtonUp("Fire1")) {
      shootTimer.restart();
    }
  }

  /*
   * Start is called before the first frame update
   * Inicializa o número e o tempo entre disparos, além da potência e da velocidade
   */
  protected override void Start () {
    base.Start();
    audioSource = GetComponent<AudioSource>();
    bulletsPerFire = 1;
    shootVelocity = 75;
  }

  #endregion

  #region Meus Métodos

  /*
   * Atira o número apropriado de tiros e toca o som do tiro
   * Os dois ifs são a lógica pra saber de qual posição o tiro vai sair
   * Um tiro entra só no segundo if e o tiro sai do meio, 
   * Dois tiros entra no primeiro e atira dos lados e 
   * Três tiros entra nos dois e atira nos dois
   */
  protected override void shootAppropriateNumberOfShoots () {
    audioSource.PlayOneShot(shootSound);
    int shootPowerTemp = bulletsPerFire;
    if (shootPowerTemp - 2 >= 0) {
      shootPowerTemp -= 2;
      instantiateAndMoveBullet(shootPositions[1], Vector3.up);
      instantiateAndMoveBullet(shootPositions[2], Vector3.up);
    }
    if (shootPowerTemp - 1 >= 0) {
      instantiateAndMoveBullet(shootPositions[0], Vector3.up);
    }
  }

  #endregion

}