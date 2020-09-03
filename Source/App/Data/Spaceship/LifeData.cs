using System;

using Assets.Source.App.Utils.Interfaces.Builders;

/// <summary>
/// Contém todas as structs referentes às naves do jogo.
/// </summary>
namespace Assets.Source.App.Data.Spaceship {

  /// <summary>
  /// Contém todos os valores referentes à vida das naves do jogo
  /// </summary>
  public struct LifeData : IData {

    #region Constantes

    public static LifeData
      BOSS_ATTACKER = new LifeData() {
        hp = 30f,
        baseShield = 60f,
        baseRegeneration = 1.5f,
        shieldRegenerationDelayTimer = 5f,
        scoreReward = 40,
      },
      BOSS_DEFENDER = new LifeData() {
        hp = 60f,
        baseShield = 120f,
        baseRegeneration = 3f,
        shieldRegenerationDelayTimer = 10f,
        scoreReward = 40,
      },
      BOSS_DODGER = new LifeData() {
        hp = 20,
        baseShield = 40,
        baseRegeneration = 1,
        shieldRegenerationDelayTimer = 3.33f,
        scoreReward = 40,
      },
      ENEMY_ATTACKER = new LifeData() {
        hp = 3f,
        baseShield = 6f,
        baseRegeneration = 0.75f,
        shieldRegenerationDelayTimer = 1f,
        scoreReward = 4,
      },
      ENEMY_DEFENDER = new LifeData() {
        hp = 6f,
        baseShield = 12f,
        baseRegeneration = 1.5f,
        shieldRegenerationDelayTimer = 2f,
        scoreReward = 4,
      },
      ENEMY_DODGER = new LifeData() {
        hp = 2f,
        baseShield = 4f,
        baseRegeneration = 0.5f,
        shieldRegenerationDelayTimer = 0.67f,
        scoreReward = 1,
      },
      ENEMY_NORMAL = new LifeData() {
        hp = 4f,
        baseShield = 8f,
        baseRegeneration = 1f,
        shieldRegenerationDelayTimer = 1.33f,
        scoreReward = 2,
      },
      PLAYER_ATTACKER = new LifeData() {
        hp = 6f,
        baseShield = 12f,
        baseRegeneration = 0.75f,
        shieldRegenerationDelayTimer = 1f,
      },
      PLAYER_DEFENDER = new LifeData() {
        hp = 12f,
        baseShield = 24f,
        baseRegeneration = 2f,
        shieldRegenerationDelayTimer = 2f,
      },
      PLAYER_DODGER = new LifeData() {
        hp = 4f,
        baseShield = 8f,
        baseRegeneration = 0.5f,
        shieldRegenerationDelayTimer = 0.67f,
      },
      PLAYER_NORMAL = new LifeData() {
        hp = 8f,
        baseShield = 16f,
        baseRegeneration = 1f,
        shieldRegenerationDelayTimer = 1.33f,
      }
    ;

    #endregion

    #region Variáveis

    public float
      hp,
      baseShield,
      baseRegeneration,
      shieldRegenerationDelayTimer
    ;

    public byte scoreReward;

    #endregion

    #region Construtores

    public LifeData (
      float hp,
      float baseShield,
      float baseRegeneration,
      float shieldRegenerationDelayTimerBaseTime,
      byte scoreReward
    ) {
      this.hp = hp;
      this.baseShield = baseShield;
      this.baseRegeneration = baseRegeneration;
      this.shieldRegenerationDelayTimer = shieldRegenerationDelayTimerBaseTime;
      this.scoreReward = scoreReward;
    }

    #endregion

  }

}
