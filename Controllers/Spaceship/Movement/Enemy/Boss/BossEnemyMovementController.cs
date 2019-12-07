using Delegates;
using Interfaces.Movements;
using UnityEngine;

public abstract class BossEnemyMovementController : EnemyMovementController, IMovement {

  #region Variáveis

  public MovementType move;
  public Vector3 _startingPosition;

  #endregion

  #region Getters e Settes

  public GameObject spaceship {
    get => _spaceship;
  }

  public Vector3 startingPosition {
    get => _startingPosition;
  }

  #endregion

  #region Métodos da Unity

  protected override void FixedUpdate () {
    if (move != null) {
      move();
    }
  }

  #endregion

  #region Meus Métodos

  public abstract void normalMovement ();

  #endregion

}
