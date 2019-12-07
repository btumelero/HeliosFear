using Interfaces;
using UnityEngine;

public abstract class BossEnemyAttackController : EnemyAttackController, IAttack, ISpecialAttack {

  #region Variáveis

  public GameObject specialBullet;
  public Timer specialShootTimer { get; set; }

  #endregion

  #region Getters e Setters

  public ISpecialAttack iSpecialAttack { 
    get => this as ISpecialAttack; 
  }

  #endregion

  #region Meus Métodos

  public abstract void normalAttack ();

  public abstract void specialAttack ();

  protected void instantiateBullet (Transform spawner, bool setAsChild) {
    if (spawner != null) {
      GameObject newSpecialBullet = Instantiate(specialBullet);
      if (setAsChild) {
        newSpecialBullet.transform.SetParent(gameObject.transform);
      }
      initializeBullet(newSpecialBullet, spawner);
    }
  }

  #endregion

  #region Métodos da Unity

  protected override void Update () {
    if (shootTimer.timeIsUp()) {
      normalAttack();
      shootTimer.restart();
    }
  }

  #endregion
}
