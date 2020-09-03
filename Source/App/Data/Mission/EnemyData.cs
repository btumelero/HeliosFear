using Assets.Source.App.Utils.Interfaces.Builders;

/// <summary>
/// Contém todas as structs referentes às missões do jogo.
/// </summary>
namespace Assets.Source.App.Data.Mission {

  /// <summary>
  /// Contém todos os valores referentes aos inimigos do jogo
  /// </summary>
  public struct EnemyData : IData {

    #region Constantes

    public static readonly EnemyData
      BOSS_ATTACKER = new EnemyData {
        spawnChance = new byte[] { 30, 10, 25, 35 },
        normalRespawnTimer = 1.25f,
        normalMissionTimer = 1,//600?
      },
      BOSS_DEFENDER = new EnemyData {
        spawnChance = new byte[] { 10, 30, 25, 35 },
        normalRespawnTimer = 1.25f,
        specialRespawnTimer = 0.3f,
        normalMissionTimer = 1,
      },
      BOSS_DODGER = new EnemyData {
        spawnChance = new byte[] { 10, 10, 50, 30 },
        normalRespawnTimer = 1.25f,
        normalMissionTimer = 1,
      },
      SURVIVAL = new EnemyData {
        spawnChance = new byte[] { 15, 15, 30, 40 },
        normalRespawnTimer = 1.125f,
        normalMissionTimer = 1,
      }
    ;

    #endregion

    #region Variáveis

    public byte[] spawnChance;

    public float
      normalRespawnTimer,
      specialRespawnTimer,
      normalMissionTimer
    ;

    #endregion

    #region Construtores

    public EnemyData (
      byte[] spawnChance,
      float normalRespawnTimer,
      float specialRespawnTimer,
      float normalMissionTimerBaseTime
    ) {
      this.spawnChance = spawnChance;
      this.normalRespawnTimer = normalRespawnTimer;
      this.specialRespawnTimer = specialRespawnTimer;
      this.normalMissionTimer = normalMissionTimerBaseTime;
    }

    #endregion

  }

}