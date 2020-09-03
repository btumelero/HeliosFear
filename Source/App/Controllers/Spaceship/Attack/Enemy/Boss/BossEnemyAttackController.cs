using System.Collections;

using Assets.Source.App.Controllers.Bullets;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Interfaces.Attacks;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Attack.Enemy.Boss {

  /// <summary>
  /// Classe responsável por controlar o comportamento de ataque geral de boss
  /// </summary>
  public abstract class BossEnemyAttackController : EnemyAttackController, ISpecialAttack {

    #region Campos

    /// <summary>
    /// O tiro especial do boss
    /// </summary>
    public GameObject specialBullet;

    #endregion

    #region Propriedades

    public CoroutineController specialAttackCoroutine { get; set; }

    /// <summary>
    /// Timer que controla o tempo entre disparos especiais
    /// </summary>
    public virtual float specialShootTimer => 
      SpaceshipData.values[gameObject.tag].attackData.specialShootTimer
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Subclasses devem implementar o método especial de ataque do boss
    /// </summary>
    public abstract IEnumerator specialAttack ();

    /// <summary>
    /// Inicializa o tiro especial e, caso setAsChild seja verdadeiro, 
    /// coloca ele como filho do objeto que tem esse script, 
    /// para que assim ele se mova junto com a nave.
    /// </summary>
    /// 
    /// <param name="shootingPosition">
    /// A posição da arma que disparou o tiro
    /// </param>
    /// 
    /// <param name="setAsChild">
    /// Se o tiro deve acompanhar o movimento da nave ou não
    /// </param>
    protected void instantiateBullet (Transform shootingPosition, bool setAsChild) {
      if (shootingPosition != null) {
        bulletController = Instantiate(specialBullet).GetComponent<BulletController>();
        bulletController.initializeBullet(shootingPosition, actualShootPower);
        if (setAsChild) {
          bulletController.transform.SetParent(transform);
        }
        bulletController.rotateBullet(shootingPosition.up);
      }
    }

    #endregion

  }
}
