using System.Collections;

using Assets.Source.App.Controllers.Bullets;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Interfaces.Attacks;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Attack {

  /// <summary>
  /// Controla o comportament de ataque da nave
  /// </summary>
  public abstract class AttackController : MonoBehaviour, IAttack {

    #region Campos

    /// <summary>
    /// O prefab do tiro da nave
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// A posição das armas da nave
    /// </summary>
    public Transform[] weapons;

    /// <summary>
    /// O dano real da nave
    /// </summary>
    public float actualShootPower;

    
    /// <summary>
    /// Controla os tiros da nave
    /// </summary>
    protected BulletController bulletController;

    #endregion

    #region Propriedades
    
    public CoroutineController normalAttackCoroutine { get; set; }

    /// <summary>
    /// O dano base da nave
    /// </summary>
    public float baseShootPower => 
      SpaceshipData.values[gameObject.tag].attackData.baseShootPower
    ;
    
    /// <summary>
    /// A velocidade dos tiros da nave
    /// </summary>
    public float bulletVelocity => 
      SpaceshipData.values[gameObject.tag].attackData.shootVelocity
    ;

    /// <summary>
    /// O tempo entre disparos
    /// </summary>
    public virtual float shootTimer =>
      SpaceshipData.values[gameObject.tag].attackData.shootTimer
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Instancia, inicializa e move o tiro.
    /// </summary>
    /// 
    /// <param name="shooter">
    /// O objeto que está disparando o tiro.
    /// </param>
    /// 
    /// <param name="direction">
    /// A direção em que o tiro deve ser disparado.
    /// Pode ser ignorado se deve ser disparado para frente.
    /// </param>
    protected void shoot (Transform shooter, Vector3? direction = null) {
      if (shooter != null) {
        bulletController = Instantiate(bulletPrefab).GetComponent<BulletController>();
        bulletController.initializeBullet(shooter, actualShootPower);
        bulletController.rotateBullet(direction ?? shooter.up);
        ((NormalBulletController) bulletController).moveBullet(bulletVelocity, direction ?? shooter.up);
      }
    }

    /// <summary>
    /// O método normal de ataque da nave
    /// </summary>
    public abstract IEnumerator normalAttack ();

    #endregion

  }
}
