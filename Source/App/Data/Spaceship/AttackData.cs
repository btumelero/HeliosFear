using Assets.Source.App.Utils.Interfaces.Builders;

/// <summary>
/// Contém todas as structs referentes às naves do jogo.
/// </summary>
namespace Assets.Source.App.Data.Spaceship {

  /// <summary>
  /// Contém todos os valores referentes ao ataque das naves do jogo
  /// </summary>
  public struct AttackData : IData {

    #region Constantes

    public static readonly AttackData
      BOSS_ATTACKER = new AttackData() {
        baseShootPower = 16,
        shootTimer = 2f,
        shootVelocity = 40f,//add special shoot timer
      },
      BOSS_DEFENDER = new AttackData() {
        baseShootPower = 4f,
        shootTimer = 2.5f,
        shootVelocity = 40f,//add special shoot timer
        specialShootTimer = 8.5f,
      },
      BOSS_DODGER = new AttackData() {
        baseShootPower = 4f,
        shootTimer = 2f,
        shootVelocity = 80f,//add special shoot timer
        specialShootTimer = 0.3f,
      },
      ENEMY_ATTACKER = new AttackData() {
        baseShootPower = 8f,
        shootTimer = 2.5f,
        shootVelocity = 20f,
      },
      ENEMY_DEFENDER = new AttackData() {
        baseShootPower = 4f,
        shootTimer = 4.5f,
        shootVelocity = 20f,
      },
      ENEMY_DODGER = new AttackData() {
        baseShootPower = 2f,
        shootTimer = 3f,
        shootVelocity = 40f,
      },
      ENEMY_NORMAL = new AttackData() {
        baseShootPower = 3f,
        shootTimer = 3.5f,
        shootVelocity = 30f,
      },
      PLAYER_ATTACKER = new AttackData() {
        baseShootPower = 2.5f,
        shootTimer = 0.15f,
        shootVelocity = 75,
      },
      PLAYER_DEFENDER = new AttackData() {
        baseShootPower = 1f,
        shootTimer = 0.3f,
        shootVelocity = 75,
      },
      PLAYER_DODGER = new AttackData() {
        baseShootPower = 1.5f,
        shootTimer = 0.25f,
        shootVelocity = 75,
      },
      PLAYER_NORMAL = new AttackData() {
        baseShootPower = 2f,
        shootTimer = 0.2f,
        shootVelocity = 75,
      }
    ;

    #endregion

    #region Variáveis

    public float
      baseShootPower,
      shootTimer,
      shootVelocity,
      specialShootTimer
    ;

    #endregion

    #region Construtores

    public AttackData (
      float baseShootPower,
      float shootTimer,
      float shootVelocity,
      float specialShootTimer
    ) {
      this.baseShootPower = baseShootPower;
      this.shootTimer = shootTimer;
      this.shootVelocity = shootVelocity;
      this.specialShootTimer = specialShootTimer;
    }

    #endregion

  }
}
