namespace Enums {

  public enum Spaceships : byte {
    Attacker, Defender, Dodger, Normal
  }

  public enum Achievement : byte {
    AdvancedEngineUnlocked,
    SpecialEngineUnlocked,
    AdvancedShieldUnlocked,
    SpecialShieldUnlocked,
    AdvancedWeaponUnlocked,
    SpecialWeaponUnlocked
  }

  public enum Player : byte {
    Score, HighScore
  }

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

  public enum Scenes : byte {
    MainMenu, SpaceshipCustomization, SpaceshipSelection, Battle, BossSelection
  }

  public enum Input : byte {
    Fire1, Shield, Speed, Weapon, Horizontal, Vertical
  }

  public enum Customization : byte { 
    Basic = 1, Advanced = 2, Special = 3 
  }

  public enum Movement : byte { 
    Leftward, Rightward, Downward, Halted
  }

  public enum Missions : byte {
    Attacker, Defender, Dodger, Survival, Tutorial
  }

}

