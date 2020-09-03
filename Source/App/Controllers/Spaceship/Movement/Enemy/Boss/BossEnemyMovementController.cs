using System.Collections;

using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Boss {

  /// <summary>
  /// Classe responsável por gerenciar os movimentos de boss
  /// </summary>
  public abstract class BossEnemyMovementController : EnemyMovementController, ISpecialMovement {

    #region Propriedades

    /// <summary>
    /// A posição especial do boss na tela
    /// </summary>
    public Vector3? specialPosition { get; set; }

    /// <summary>
    /// A posição inicial do boss na tela
    /// </summary>
    public Vector3 startingPosition =>
      SpaceshipData.values[gameObject.tag].movementData.startingPosition
    ;

    /// <summary>
    /// O tempo entre as mudanças entre diferentes tipos de movimentações
    /// </summary>
    public float movementTypeTimer =>
      SpaceshipData.values[gameObject.tag].movementData.movementTypeTimer
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// A forma especial do boss se movimentar
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    public abstract IEnumerator specialMovement ();

    /// <summary>
    /// Alterna entre os dois tipos de movimentação do boss.
    /// </summary>
    /// 
    /// <param name="previousMovement">
    /// O movimento que o boss realizou antes dessa coroutine.
    /// </param>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina.
    /// </returns>
    public abstract IEnumerator switchMovements (IEnumerator previousMovement);

    #endregion

  }
}
