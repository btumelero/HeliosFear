using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar os movimentos dos inimigos comuns
/// </summary>
public abstract class CommonEnemyMovementController : EnemyMovementController {

  #region Variáveis

  /// <summary>
  /// Timer que controla o tempo entre mudanças na movimentação
  /// </summary>
  public FixedTimer switchTimer { get; set; }

  /// <summary>
  /// O corpo da nave
  /// </summary>
  public Rigidbody _spaceshipBody { get; set; }

  /// <summary>
  /// A direção em que a nave está se movendo
  /// </summary>
  protected Enums.Movement _moving;

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Atualiza a direção em que a nave está se movendo ao mudar o valor
  /// </summary>
  public Enums.Movement moving {
    get => _moving;
    set {
      _moving = value;
      updateMovementDirection();
    }
  }

  /// <summary>
  /// O corpo da nave
  /// </summary>
  public Rigidbody spaceshipBody {
    get => _spaceshipBody;
    set => _spaceshipBody = value;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Muda a direção em que a nave está indo quando o timer esgota e reinicia o timer
  /// </summary>
  protected override void FixedUpdate () {
    if (switchTimer.timeIsUp()) {
      directionSwitch();
      switchTimer.restart();
    }
  }

  /// <summary>
  /// Desativa a nave quando ela não está visível na tela
  /// </summary>
  public virtual void OnBecameInvisible () {
    gameObject.SetActive(false);
  }

  #endregion


  #region Meus métodos

  /// <summary>
  /// Deve mudar a direção da nave
  /// </summary>
  public abstract void directionSwitch ();

  /// <summary>
  /// Deve atualizar a direção em que a nave está indo
  /// </summary>
  protected abstract void updateMovementDirection ();

  #endregion
}
