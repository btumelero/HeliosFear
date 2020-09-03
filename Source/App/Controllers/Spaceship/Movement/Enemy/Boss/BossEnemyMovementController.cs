using Delegates;

using Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar os movimentos de boss
/// </summary>
public abstract class BossEnemyMovementController : EnemyMovementController, IMovement {

  #region Variáveis

  /// <summary>
  /// A forma como o boss está se movendo.
  /// Um delegate é usado para dar mais flexibilidade para a manipulação
  /// </summary>
  public MovementType move;

  /// <summary>
  /// A posição especial do boss na tela
  /// </summary>
  public Vector3 _startingPosition;


  /// <summary>
  /// Timer que controla o intervalo entre a mudança entre formas de movimentação
  /// </summary>
  public Timer movementTypeTimer { get; set; }

  #endregion

  #region Getters e Settes

  /// <summary>
  /// A nave do boss
  /// </summary>
  public GameObject spaceship {
    get => _spaceship;
  }

  /// <summary>
  /// A posição inicial do boss na tela
  /// </summary>
  public Vector3 startingPosition {
    get => _startingPosition;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Dependendo do boss, ele poderá ter várias formas diferentes de se movimentar
  /// </summary>
  protected override void FixedUpdate () {
    move?.Invoke();
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// A forma normal do boss se movimentar
  /// </summary>
  public abstract void normalMovement ();

  #endregion

}
