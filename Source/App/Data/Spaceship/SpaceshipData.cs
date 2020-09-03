using System.Collections.Generic;

using Assets.Source.App.Utils.Interfaces.Builders;

/// <summary>
/// Contém todas as structs referentes às naves do jogo.
/// </summary>
namespace Assets.Source.App.Data.Spaceship {

  /// <summary>
  /// Reúne, para facilidade de acesso, dados referentes à:
  /// Ataque, Energia, Movimento e Vida de cada tipo de nave.
  /// </summary>
  public struct SpaceshipData : IDataGroup {

    #region Constantes

    /// <summary>
    /// Usado para acessar dados de uma nave a partir de sua tag.
    /// </summary>
    public static readonly Dictionary<string, SpaceshipData> values = new Dictionary<string, SpaceshipData>() {
      {
        "Enemy Attacker",
        new SpaceshipData(
          AttackData.ENEMY_ATTACKER,
          EnergyData.ENEMY_ATTACKER,
          LifeData.ENEMY_ATTACKER,
          MovementData.ENEMY_ATTACKER
        )
      },
      {
        "Enemy Defender",
        new SpaceshipData (
          AttackData.ENEMY_DEFENDER,
          EnergyData.ENEMY_DEFENDER,
          LifeData.ENEMY_DEFENDER,
          MovementData.ENEMY_DEFENDER
        )
      },
      {
        "Enemy Dodger",
        new SpaceshipData (
          AttackData.ENEMY_DODGER,
          EnergyData.ENEMY_DODGER,
          LifeData.ENEMY_DODGER,
          MovementData.ENEMY_DODGER
        )
      },
      {
        "Enemy Normal",
        new SpaceshipData (
          AttackData.ENEMY_NORMAL,
          EnergyData.ENEMY_NORMAL,
          LifeData.ENEMY_NORMAL,
          MovementData.ENEMY_NORMAL
        )
      },
      {
        "Player Attacker",
        new SpaceshipData (
          AttackData.PLAYER_ATTACKER,
          EnergyData.PLAYER_ATTACKER,
          LifeData.PLAYER_ATTACKER,
          MovementData.PLAYER_ATTACKER
        )
      },
      {
        "Player Defender",
        new SpaceshipData (
          AttackData.PLAYER_DEFENDER,
          EnergyData.PLAYER_DEFENDER,
          LifeData.PLAYER_DEFENDER,
          MovementData.PLAYER_DEFENDER
        )
      },
      {
        "Player Dodger",
        new SpaceshipData (
          AttackData.PLAYER_DODGER,
          EnergyData.PLAYER_DODGER,
          LifeData.PLAYER_DODGER,
          MovementData.PLAYER_DODGER
        )
      },
      {
        "Player Normal",
        new SpaceshipData (
          AttackData.PLAYER_NORMAL,
          EnergyData.PLAYER_NORMAL,
          LifeData.PLAYER_NORMAL,
          MovementData.PLAYER_NORMAL
        )
      },
      {
        "Boss Attacker",
        new SpaceshipData (
          AttackData.BOSS_ATTACKER,
          EnergyData.BOSS_ATTACKER,
          LifeData.BOSS_ATTACKER,
          MovementData.BOSS_ATTACKER
        )
      },
      {
        "Boss Defender",
        new SpaceshipData (
          AttackData.BOSS_DEFENDER,
          EnergyData.BOSS_DEFENDER,
          LifeData.BOSS_DEFENDER,
          MovementData.BOSS_DEFENDER
        )
      },
      {
        "Boss Dodger",
        new SpaceshipData (
          AttackData.BOSS_DODGER,
          EnergyData.BOSS_DODGER,
          LifeData.BOSS_DODGER,
          MovementData.BOSS_DODGER
        )
      },
    };

    #endregion

    #region Variáveis

    public AttackData attackData;
    public EnergyData energyData;
    public LifeData lifeData;
    public MovementData movementData;

    #endregion

    #region Construtores

    public SpaceshipData (
      AttackData attackData,
      EnergyData energyData,
      LifeData lifeData,
      MovementData movementData
    ) {
      this.attackData = attackData;
      this.energyData = energyData;
      this.lifeData = lifeData;
      this.movementData = movementData;
    }

    #endregion

  }
}
