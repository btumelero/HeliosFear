using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar os movimentos dos inimigos
/// </summary>
public abstract class EnemyMovementController : MovementController {

  #region Variáveis

  /// <summary>
  /// A nave inimiga
  /// </summary>
  public GameObject _spaceship { get; set; }

  #endregion

}
