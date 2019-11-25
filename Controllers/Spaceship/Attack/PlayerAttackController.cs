using UnityEngine;

public class PlayerAttackController : AttackController {

  #region Variáveis

  public AudioClip shootSound;
  public AudioSource audioSource { get; set; }
  public int bulletsPerFire;

  #endregion

  #region Métodos da Unity

  /*
  * Atira sempre que o jogador apertar o botão apropriado e continua atirando a cada X segundos se ele segurar apertado
  */
  protected override void Update () {
    if (Input.GetButtonDown(Enums.Input.Fire1.ToString())) {
      shootAppropriateNumberOfShoots();
    } else if (Input.GetButton(Enums.Input.Fire1.ToString())) {
      if (shootTimer.timeIsUp()) {
        shootAppropriateNumberOfShoots();
        shootTimer.restart();
      }
    } else if (Input.GetButtonUp(Enums.Input.Fire1.ToString())) {
      shootTimer.restart();
    }
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
