using Assets.Source.App.Data.Spaceship;

using UnityEngine;
using System.Collections;
using Assets.Source.App.Utils.Coroutines;

/// <summary>
/// Contém todas as classes responsáveis pela movimentação de naves do jogo
/// </summary>
namespace Assets.Source.App.Controllers.Spaceship.Movement {

  /// <summary>
  /// Classe responsável por gerenciar o movimento
  /// </summary>
  public abstract class MovementController : MonoBehaviour {

    #region Propriedades

    public CoroutineController movementCoroutine { get; set; }

    /// <summary>
    /// A velocidade real/atual do objeto
    /// </summary>
    public float actualSpeed { get; set; }

    /// <summary>
    /// A velocidade base do objeto
    /// </summary>
    public virtual float baseSpeed =>
      SpaceshipData.values[gameObject.tag].movementData.baseSpeed
    ;


    #endregion

    #region Meus Métodos

    /// <summary>
    /// A forma de movimentação normal da nave
    /// </summary>
    public abstract IEnumerator normalMovement ();

    #endregion

  }
}
