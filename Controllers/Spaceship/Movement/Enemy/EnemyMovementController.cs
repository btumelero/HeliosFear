using UnityEngine;

public abstract class EnemyMovementController : MovementController {

  #region Variáveis

  public Rigidbody spaceship { get; set; }
  public FixedTimer switchTimer { get; set; }
  protected movementType _moving;
  public enum movementType : byte { LEFTWARD = 0, RIGHTWARD = 1, DOWNWARD = 2, HALTED = 3 };

  #endregion

  #region Getters e Setters

  public movementType moving {
    get => _moving;
    set {
      _moving = value;
      updateMovementDirection();
    }
  }

  #endregion

  #region Métodos da Unity

  /*
   * retorna verdadeiro se a nave mudou de direção
   */
  protected override void FixedUpdate () {
    if (switchTimer.timeIsUp()) {
      directionSwitch();
      switchTimer.restart();
    }
  }

  #endregion

  #region Meus métodos

  /*
   * Muda a direção da nave
   */
  public abstract void directionSwitch ();

  /*
   * Atualiza a direção em que a nave está indo
   */
  protected abstract void updateMovementDirection ();

  #endregion

}
