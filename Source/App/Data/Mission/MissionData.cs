using System.Collections.Generic;

using Assets.Source.App.Controllers.Mission;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Interfaces.Builders;

/// <summary>
/// Contém todas as structs referentes às missões do jogo.
/// </summary>
namespace Assets.Source.App.Data.Mission {

  /// <summary>
  /// Reúne, para facilidade de acesso, dados referentes à:
  /// Inimigos e jogador.
  /// </summary>
  public struct MissionData : IDataGroup {

    #region Constantes

    public static readonly Dictionary<Missions, MissionData> values = new Dictionary<Missions, MissionData>() {
      {
        Missions.Attacker,
        new MissionData (
          EnemyData.BOSS_ATTACKER,
          PlayerData.BOSS_ATTACKER
        )
      },
      {
        Missions.Defender,
        new MissionData (
          EnemyData.BOSS_DEFENDER,
          PlayerData.BOSS_DEFENDER
        )
      },
      {
        Missions.Dodger,
        new MissionData (
          EnemyData.BOSS_DODGER,
          PlayerData.BOSS_DODGER
        )
      },
      {
        Missions.Survival,
        new MissionData (
          EnemyData.SURVIVAL,
          PlayerData.SURVIVAL
        )
      },
    };

    #endregion

    #region Variáveis

    #region Estáticas

    /// <summary>
    /// O nome da missão que o jogador escolheu
    /// </summary>
    public static Missions missionName = Missions.Test;

    /// <summary>
    /// O controlador da missão escolhida pelo jogador
    /// </summary>
    public static MissionController missionController;

    #endregion

    public EnemyData enemyData;
    public PlayerData playerData;

    #endregion

    #region Construtores

    public MissionData (
      EnemyData enemyData,
      PlayerData playerData
    ) {
      this.enemyData = enemyData;
      this.playerData = playerData;
    }

    #endregion

  }

}