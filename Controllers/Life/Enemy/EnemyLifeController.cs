using UnityEngine;

public abstract class EnemyLifeController : LifeController {

  #region Variáveis

  private EnemyController enemyController;

  #endregion

  #region Getters e Setters

  public override float hp {
    get => _hp;
    set {
      _hp = value;
      //Debug.Log("HP " + hp);
      //Debug.Log("SHIELD " + shield);
      if (_hp <= 0) {
        dead = true;
        enemyController.spawnPower();
      }
    }
  }

  public override float maxShield { get; set; }

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    enemyController = GetComponent<EnemyController>();
    regenerationTimer = gameObject.AddComponent<Timer>();
  }

  #endregion
}
