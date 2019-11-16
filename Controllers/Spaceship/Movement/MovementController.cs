using UnityEngine;

public abstract class MovementController : MonoBehaviour {

  #region Variáveis

  public float baseSpeed { get; set; }
  public float actualSpeed { get; set; }

  #endregion


  #region Métodos da Unity

  protected abstract void FixedUpdate ();

  protected abstract void Start ();

  #endregion

}
