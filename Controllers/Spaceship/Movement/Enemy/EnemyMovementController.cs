using UnityEngine;

public abstract class EnemyMovementController : MovementController {

  #region Variáveis

  public Rigidbody spaceship { get; set; }
  public FixedTimer switchTimer { get; set; }
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
