using UnityEngine;

public abstract class CommonEnemyMovementController : EnemyMovementController {

  #region Variáveis

  public FixedTimer switchTimer { get; set; }
  public Rigidbody _spaceshipBody;
  protected Enums.Movement _moving;

  #endregion

  #region Getters e Setters

  public Enums.Movement moving {
    get => _moving;
    set {
      _moving = value;
      updateMovementDirection();
    }
  }

  public Rigidbody spaceshipBody {
    get => _spaceshipBody;
    set => _spaceshipBody = value;
  }

  #endregion

  #region Métodos da Unity

  /**
   * retorna verdadeiro se a nave mudou de direção
   */
  protected override void FixedUpdate () {
    if (switchTimer.timeIsUp()) {
      directionSwitch();
      switchTimer.restart();
    }
  }

  public virtual void OnBecameInvisible () {
    gameObject.SetActive(false);
  }

  #endregion


  #region Meus métodos

  /**
   * Muda a direção da nave
   */
  public abstract void directionSwitch ();

  /**
   * Atualiza a direção em que a nave está indo
   */
  protected abstract void updateMovementDirection ();

  #endregion
}
