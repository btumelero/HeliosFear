using Interfaces.Movements;
using UnityEngine;

public abstract class MovementController : MonoBehaviour, IMove {

  #region Variáveis

  public float _baseSpeed;

  public float _actualSpeed;

  #endregion

  #region Getters e Setters

  public float baseSpeed {
    get => _baseSpeed;
  }

  public float actualSpeed {
    get => _actualSpeed;
  }

  #endregion

  #region Métodos da Unity

  protected abstract void FixedUpdate ();

  #endregion

}
