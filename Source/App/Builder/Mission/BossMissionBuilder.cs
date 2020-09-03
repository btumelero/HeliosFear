using Assets.Source.App.Controllers.Mission.BossMission;
using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Timers;

using UnityEngine;

/// <summary>
/// Contém todas as classes responsáveis por construir as missões do jogo
/// </summary>
namespace Assets.Source.App.Builders.Mission {

  /// <summary>
  /// Classe responsável por construir as missões de bosses do jogo
  /// </summary>
  public class BossMissionBuilder : MissionBuilder {

    #region Propriedades

    /// <summary>
    /// Retorna o controlador da missão convertido para o tipo necessário na classe
    /// </summary>
    protected new BossMissionController missionController =>
      (BossMissionController) MissionData.missionController;

    #endregion

    #region Métodos

    /// <summary>
    /// Inicializações referentes aos inimigos
    /// </summary>
    /// 
    /// <param name="enemyData">
    /// Os dados dos inimigos da missão
    /// </param>
    public override void onBuild (EnemyData enemyData) {
      base.onBuild(enemyData);
      missionController.respawnController = respawnController;
      if (MissionData.missionController is BossDefenderMissionController bossDefenderMC) {
        bossDefenderMC.respawnZones = respawnZones;
      }
    }

    public override void onBuild (GameObject mission) {
      base.onBuild(mission);
      missionController.missionEndCoroutine =
        missionController.gameObject.AddComponent<CoroutineController>()
      ;
    }

    #endregion

  }
}