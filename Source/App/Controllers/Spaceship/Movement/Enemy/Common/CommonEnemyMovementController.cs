using System.Collections;

using Assets.Source.App.Controllers.Respawn;
using Assets.Source.Experimental;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Common {

  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(MeshRenderer))]
  /// <summary>
  /// Classe responsável por gerenciar os movimentos dos inimigos comuns
  /// </summary>
  public abstract class CommonEnemyMovementController : EnemyMovementController {

    #region Campos

    /// <summary>
    /// O corpo da nave
    /// </summary>
    [HideInInspector] public Rigidbody spaceshipBody;

    /// <summary>
    /// A direção em que a nave está se movendo
    /// </summary>
    public FieldWithAction<int> moving;

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Desativa a nave quando ela não está visível na tela
    /// </summary>
    protected virtual void OnBecameInvisible () {
      gameObject.SetActive(false);
    }

    /// <summary>
    /// Armazena o inimigo para reutilização usando a técnica Pooling
    /// </summary>
    private void OnDisable () {
      Pooling.store(gameObject);
    }

    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// Muda a direção em que a nave está indo quando o timer esgota e reinicia o timer
    /// </summary>
    public override IEnumerator normalMovement () {
      while (true) {
        yield return new WaitForSeconds(movementTimer);
        switchMovementDirection();
      }
    }

    #endregion

    #region Meus métodos

    /// <summary>
    /// Deve mudar a direção da nave
    /// </summary>
    public abstract void switchMovementDirection ();

    /// <summary>
    /// Deve atualizar a direção em que a nave está indo
    /// </summary>
    public abstract void onMovingValueChanged ();

    #endregion

  }

}
