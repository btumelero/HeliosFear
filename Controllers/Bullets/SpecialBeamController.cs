using UnityEngine;

public class SpecialBeamController : SpecialBulletController {

  #region Variáveis

  public float min, max;
  public bool increase;

  #endregion

  #region Métodos da Unity

  protected override void Start () {
    base.Start();
    autoDestroyTimer.baseTime = 2;
    increase = true;
    min = 0.8f;
    max = 1.2f;
  }

  /**
   * Update is called once per frame
   * 
   * 
   */
  protected override void Update () {
    base.Update();
    transform.localScale = new Vector3(
      increase ? transform.localScale.x + Time.deltaTime : transform.localScale.x - Time.deltaTime,
      transform.localScale.y < 1 ? transform.localScale.y + (Time.deltaTime * 3) : 1,
      transform.localScale.z
    );
    if (transform.localScale.x >= max || transform.localScale.x <= min) {
      increase = !increase;
    }
  }

  #endregion

}
