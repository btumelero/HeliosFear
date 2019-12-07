using System;
using Extensions;
using UnityEngine;

/**
 * Controla o comportamento de ataque das naves
 */
public abstract class AttackController : MonoBehaviour {

  #region Variáveis

  /**
   * A bala que será atirada pela nave.
   * Deve estar marcada com tag FriendlyBullet ou EnemyBullet para detecção de colisões
   * Inicializado pela interface da Unity
   */
  public GameObject bullet;

  /**
   * As armas da nave (objeto invisível na frente das armas, na verdade). 
   * Devem estar voltadas na direção em que o tiro deve ser disparado.
   * Inicializado pela interface da Unity
   */
  public Transform[] weapons;

  /**
   * Timer para controlar o tempo entre um disparo e outro
   * O '{ get; set; }' é para evitar que esta variável apareça na interface da Unity, 
   * já que ele é adicionado por código ao invés de 'arrastar e soltar' pela interface da Unity.
   */
  public Timer shootTimer { get; set; }

  /**
   * Potência atual/verdadeira das armas.
   * É a potência base vezes o multiplicador de potência do slider da tela (controlado pelo jogador)
   */
  public float actualShootPower;

  /**
   * Potência base das armas.
   */
  public float baseShootPower;

  /**
   * A velocidade do tiro na tela
   */
  public float shootVelocity;

  #endregion

  #region Métodos da Unity

  /**
   * Update is called once per frame
   * 
   * Deverá ser sobreescrito pelas classes filhas para dar o comportamento de ataque de cada nave
   */
  protected abstract void Update ();

  #endregion

  #region Meus Métodos

  /**
   * Instancia, move, rotaciona, dá velocidade e potência ao tiro.
   */
  protected void instantiateRotateAndMoveBullet (Transform spawner, Nullable<Vector3> direction = null) {
    if (spawner != null) {
      GameObject newBullet = Instantiate(bullet);
      Rigidbody bulletBody = newBullet.GetComponent<Rigidbody>();
      initializeBullet(newBullet, spawner);
      moveBullet(spawner, bulletBody, direction);
      rotateBullet(bulletBody);
    }
  }

  protected void initializeBullet (GameObject newBullet, Transform spawner) {
    newBullet.transform.position = spawner.position;
    newBullet.GetComponent<BulletController>().shootPower = baseShootPower;
  }

  private void moveBullet (Transform spawner, Rigidbody bulletBody, Nullable<Vector3> direction = null) {
    bulletBody.setVelocity(direction ?? spawner.up, shootVelocity);
  }


  private void rotateBullet (Rigidbody bulletBody) {
    bulletBody.fixRotation();
  }

  #endregion

}
