using UnityEngine;

/// <summary>
/// Uma das classes responsáveis pela destruição de objetos
/// </summary>
public class TimedObjectDestroyer : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// Timer que controla o tempo até a destruição do objeto
  /// </summary>
  private Timer timer;

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicializa o timer com 5 segundos
  /// </summary>
  private void Start () {
    timer = gameObject.AddComponent<Timer>();
    timer.baseTime = 5;
  }

  /// <summary>
  /// Destrói o objeto que tem esse script depois que o timer zerar
  /// </summary>
  private void Update () {
    if (timer.timeIsUp()) {
      Destroy(gameObject.transform.root.gameObject);
    }
  }
  
  #endregion

}
