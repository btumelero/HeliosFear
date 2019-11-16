public class EnemyDodgerController : EnemyController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa o score que vai ser dado pro jogador caso ele destrua essa nave
   */
  protected override void Start () {
    base.Start();
    scoreReward = 1;
  }

  #endregion

}
