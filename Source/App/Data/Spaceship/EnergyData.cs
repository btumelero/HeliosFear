using Assets.Source.App.Utils.Interfaces.Builders;

/// <summary>
/// Contém todas as structs referentes às naves do jogo.
/// </summary>
namespace Assets.Source.App.Data.Spaceship {

  /// <summary>
  /// Contém todos os valores referentes à energia das naves do jogo
  /// </summary>
  public struct EnergyData : IData {

    #region Constantes

    public static readonly EnergyData
      BOSS_ATTACKER = new EnergyData() {
        totalEnergy = 300,
        shieldMultiplier = 80,
        speedMultiplier = 80,
        weaponMultiplier = 140,
      },
      BOSS_DEFENDER = new EnergyData() {
        totalEnergy = 300,
        shieldMultiplier = 140,
        speedMultiplier = 80,
        weaponMultiplier = 80,
      },
      BOSS_DODGER = new EnergyData() {
        totalEnergy = 300,
        shieldMultiplier = 80,
        speedMultiplier = 140,
        weaponMultiplier = 80,
      },
      ENEMY_ATTACKER = new EnergyData() {
        totalEnergy = 150,
        shieldMultiplier = 30,
        speedMultiplier = 50,
        weaponMultiplier = 70,
      },
      ENEMY_DEFENDER = new EnergyData() {
        totalEnergy = 150,
        shieldMultiplier = 70,
        speedMultiplier = 50,
        weaponMultiplier = 30,
      },
      ENEMY_DODGER = new EnergyData() {
        totalEnergy = 150,
        shieldMultiplier = 40,
        speedMultiplier = 70,
        weaponMultiplier = 40,
      },
      ENEMY_NORMAL = new EnergyData() {
        totalEnergy = 150,
        shieldMultiplier = 50,
        speedMultiplier = 50,
        weaponMultiplier = 50,
      },
      PLAYER_ATTACKER = new EnergyData() {

      },
      PLAYER_DEFENDER = new EnergyData() {

      },
      PLAYER_DODGER = new EnergyData() {

      },
      PLAYER_NORMAL = new EnergyData() {

      }
    ;

    #endregion

    #region Variáveis

    public float
      totalEnergy,
      shieldMultiplier,
      speedMultiplier,
      weaponMultiplier
    ;

    #endregion

    #region Construtores

    public EnergyData (
      float totalEnergy,
      float shieldMultiplier,
      float speedMultiplier,
      float weaponMultiplier
    ) {
      this.totalEnergy = totalEnergy;
      this.weaponMultiplier = weaponMultiplier;
      this.speedMultiplier = speedMultiplier;
      this.shieldMultiplier = shieldMultiplier;
    }

    #endregion

  }
}
