using Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar o movimento
/// </summary>
public abstract class MovementController : MonoBehaviour, IMove {

  #region Variáveis

  /// <summary>
  /// A velocidade base do objeto
  /// </summary>
  public float _baseSpeed;

  /// <summary>
  /// A velocidade real/atual do objeto
  /// </summary>
  public float _actualSpeed;

  #endregion

  #region Getters e Setters
  
  /// <summary>
  /// A velocidade base do objeto
  /// </summary>
  public float baseSpeed {
    get => _baseSpeed;
  }

  /// <summary>
  /// A velocidade real/atual do objeto
  /// </summary>
  public float actualSpeed {
    get => _actualSpeed;
  }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Subclasses devem implementar a lógica de movimentação do objeto
  /// </summary>
  protected abstract void FixedUpdate ();

  #endregion

}
