using System;

using Delegates;

using Extensions;

using Interfaces;

using UnityEngine;

/// <summary>
/// Controla o comportamento de ataque das naves
/// </summary>
public abstract class AttackController : MonoBehaviour, IAttack {

  #region Variáveis

  /// <summary>
  /// A forma como o objeto está atacando.
  /// Um delegate é usado para dar mais flexibilidade para a manipulação
  /// </summary>
  public AttackType attack;

  /// <summary>
  /// A bala que será atirada pela nave.
  /// Deve estar marcada com tag FriendlyBullet ou EnemyBullet para detecção de colisões
  /// Inicializado pela interface da Unity
  /// </summary>
  public GameObject bulletPrefab;

  /// <summary>
  /// As armas da nave (objeto invisível na frente das armas, na verdade). 
  /// Devem estar voltadas na direção em que o tiro deve ser disparado.
  /// Inicializado pela interface da Unity
  /// </summary>
  public Transform[] weapons;

  /// <summary>
  /// Timer para controlar o tempo entre um disparo e outro
  /// O '{ get; set; }' é para evitar que esta variável apareça na interface da Unity, 
  /// já que ele é adicionado por código ao invés de 'arrastar e soltar' pela interface da Unity.
  /// </summary>
  public Timer shootTimer { get; set; }

  /// <summary>
  /// Potência atual/verdadeira das armas.
  /// É a potência base vezes o multiplicador de potência do slider da tela (controlado pelo jogador)
  /// </summary>
  public float actualShootPower;

  /// <summary>
  /// Potência base das armas.
  /// </summary>
  public float baseShootPower;

  /// <summary>
  /// A velocidade do tiro na tela
  /// </summary>
  public float shootVelocity;

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Dependendo da nave, ela poderá ter várias formas diferentes de atacar
  /// </summary>
  protected void Update () {
    attack?.Invoke();
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Instancia, move, rotaciona, dá velocidade e potência ao tiro.
  /// </summary>
  /// 
  /// <param name="spawner">
  /// O objeto que disparou o tiro
  /// </param>
  /// 
  /// <param name="direction">
  /// A direção em que o tiro deve ser disparado. Pode ser ignorado se deve se disparado para frente.
  /// </param>
  protected void instantiateRotateAndMoveBullet (Transform spawner, Nullable<Vector3> direction = null) {
    if (spawner != null) {
      GameObject newBullet = Instantiate(bulletPrefab);
      Rigidbody bulletBody = newBullet.GetComponent<Rigidbody>();
      initializeBullet(newBullet, spawner);
      moveBullet(bulletBody, spawner, direction);
      rotateBullet(bulletBody);
    }
  }

  /// <summary>
  /// Inicializa o tiro, colocando-o na posição do spawner e dando a potência adequada
  /// </summary>
  /// 
  /// <param name="newBullet">
  /// O tiro a ser disparado
  /// </param>
  /// 
  /// <param name="spawner">
  /// O objeto que disparou o tiro
  /// </param>
  protected void initializeBullet (GameObject newBullet, Transform spawner) {
    newBullet.transform.position = spawner.position;
    newBullet.GetComponent<BulletController>().shootPower = baseShootPower;
  }

  /// <summary>
  /// Faz a bala se mover. Se direction foi ignorado, então dispara para frente.
  /// </summary>
  /// 
  /// <param name="spawner">
  /// O objeto que disparou o tiro
  /// </param>
  /// 
  /// <param name="bulletBody">
  /// O corpo do tiro
  /// </param>
  /// 
  /// <param name="direction">
  /// A direção em que o tiro deve ser disparado. Pode ser ignorado se deve se disparado para frente.
  /// </param>
  private void moveBullet (Rigidbody bulletBody, Transform spawner, Nullable<Vector3> direction = null) {
    bulletBody.setVelocity(direction ?? spawner.up, shootVelocity);
  }

  /// <summary>
  /// Rotaciona o tiro na direção do movimento dele.
  /// </summary>
  /// 
  /// <param name="bulletBody">
  /// O corpo do tiro
  /// </param>
  private void rotateBullet (Rigidbody bulletBody) {
    bulletBody.fixRotation();
  }

  /// <summary>
  /// Subclasses devem implementar o método normal de ataque
  /// </summary>
  public abstract void normalAttack ();

  #endregion

}
