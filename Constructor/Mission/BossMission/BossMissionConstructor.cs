/// <summary>
/// Classe responsável por inicializar variáveis que as missões de boss têm em comum.
/// </summary>
public class BossMissionConstructor : MissionConstructor {

  #region Getters e Setters

  public new BossMissionController missionController {
    get => (BossMissionController) _missionController;
  }

  #endregion

  #region Meus Métodos

  protected override void setUpMissionController () {
    base.setUpMissionController();
    missionController.respawnController = _respawnController;
    missionController.normalMissionTimer = missionController.gameObject.AddComponent<Timer>();
    missionController.normalMissionTimer.baseTime = 1;//***************************************************************************************
  }

  #endregion
}
