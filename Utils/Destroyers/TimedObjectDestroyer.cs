using UnityEngine;

public class TimedObjectDestroyer : MonoBehaviour {

  #region Variáveis

  private Timer timer;

  #endregion

  #region Métodos da Unity

  /*
   *  Start is called before the first frame update
   *  Inicializa o timer com 5 segundos
   */
  private void Start () {
    timer = gameObject.AddComponent<Timer>();
    timer.baseTime = 5;
  }

  /*
   * Update is called once per frame
   * Destrói o objeto que tem esse script depois que o timer zerar
   */
  private void Update () {
    if (timer.timeIsUp()) {
      Destroy(gameObject);
    }
  }
  
  #endregion

}
