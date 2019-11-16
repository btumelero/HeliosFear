public class EnemyDefenderController : EnemyController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa o score que vai ser dado pro jogador caso ele destrua essa nave
   */
  protected override void Start () {
    GetComponent<EnemyDefenderMovementController>().moving = EnemyMovementController.movementType.DOWNWARD;
    scoreReward = 4;
  }

  #endregion

}
