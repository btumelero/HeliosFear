/// <summary>
/// Contém os enums usados no projeto
/// </summary>
namespace Assets.Source.App.Utils.Enums {

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
    EvolvedEngineUnlocked,
    SpecialEngineUnlocked,
    EvolvedShieldUnlocked,
    SpecialShieldUnlocked,
    EvolvedWeaponUnlocked,
    SpecialWeaponUnlocked
  }

  /// <summary>
  /// Outras tags
  /// </summary>
  public enum Tags : byte {
    Canvas,
    BlackSides,
    Bullet,
    Boss,
    Edges,
    EnemyBullet,
    FriendlyBullet,
    HighScore,
    RemainingShieldSlider,
    RemainingHpSlider,
    Score,
    ShieldSlider,
    SpawningZone,
    SpeedSlider,
    WeaponSlider,
  }

  /// <summary>
  /// Nomes das cenas
  /// </summary>
  public enum Scenes : byte {
    Menu, Battle
  }

  /// <summary>
  /// Possíveis Inputs do jogador
  /// </summary>
  public enum Inputs : byte {
    Fire1, Shield, Speed, Weapon, Horizontal, Vertical
  }

  /// <summary>
  /// O nível da customização escolhida pelo jogador
  /// </summary>
  public enum Customization : byte {
    Basic = 1, Evolved = 2, Special = 3
  }

  /// <summary>
  /// Direção do movimento da nave inimiga
  /// </summary>
  public enum Movements {
    Leftward = -1, Downward = 0, Rightward = 1, Halted = 2
  }

  /// <summary>
  /// As missões disponíveis
  /// </summary>
  public enum Missions : int {
    Attacker, Defender, Dodger, Survival = -1, Tutorial = -2, Test = -3
  }

  /// <summary>
  /// Aumentar ou diminuir a transparência
  /// </summary>
  public enum Fade {
    In = -1, Out = 1
  }

  /// <summary>
  /// Os três sliders da tela que permitem o jogador distribuir a energia da nave
  /// </summary>
  public enum Sliders {
    Shield, Speed, Weapon
  }

}