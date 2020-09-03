/// <summary>
/// Contém os enums usados no projeto
/// </summary>
namespace Enums {

  /// <summary>
  /// Os tipos de nave do jogo
  /// </summary>
  public enum Spaceships : byte {
    Attacker, Defender, Dodger, Normal
  }

  /// <summary>
  /// As conquistas que podem ser alcançadas
  /// </summary>
  public enum Achievement : byte {
    AdvancedEngineUnlocked,
    SpecialEngineUnlocked,
    AdvancedShieldUnlocked,
    SpecialShieldUnlocked,
    AdvancedWeaponUnlocked,
    SpecialWeaponUnlocked
  }

  /// <summary>
  /// Tags relacionadas ao jogador
  /// </summary>
  public enum Player : byte {
    Score, HighScore
  }

  /// <summary>
  /// Outras tags
  /// </summary>
  public enum Tags : byte {
    ShieldSlider, 
    SpeedSlider, 
    WeaponSlider, 
    RemainingHpSlider, 
    RemainingShieldSlider, 
    Player,
    Enemy,
    PlayerShield, 
    EnemyShield,
    EnemyBullet,
    FriendlyBullet,
    Canvas,
    Bullet,
    Edges,
    Boss,
    BlackSides,
    SpawningZone
  }

  /// <summary>
  /// Nomes das cenas
  /// </summary>
  public enum Scenes : byte {
    MainMenu, SpaceshipCustomization, SpaceshipSelection, Battle, BossSelection
  }

  /// <summary>
  /// Possíveis Inputs do jogador
  /// </summary>
  public enum Input : byte {
    Fire1, Shield, Speed, Weapon, Horizontal, Vertical
  }

  /// <summary>
  /// O nível da customização escolhida pelo jogador
  /// </summary>
  public enum Customization : byte { 
    Basic = 1, Advanced = 2, Special = 3 
  }

  /// <summary>
  /// Direção do movimento da nave inimiga
  /// </summary>
  public enum Movement : byte { 
    Leftward, Rightward, Downward, Halted
  }

  /// <summary>
  /// As missões disponíveis
  /// </summary>
  public enum Missions : byte {
    Attacker, Defender, Dodger, Survival, Tutorial
  }

}

