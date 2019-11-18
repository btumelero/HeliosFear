using UnityEngine;

public abstract class MovementController : MonoBehaviour {

  #region Variáveis

  public float baseSpeed;
  public float actualSpeed;

  #endregion

  #region Métodos da Unity

  protected abstract void FixedUpdate ();

  #endregion

}
