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
    Bullet
  }

  public enum Scenes : byte {
    MainMenu, SpaceshipCustomization, SpaceshipSelection, Survival
  }

  public enum Input : byte {
    Fire1, Shield, Speed, Weapon, Horizontal, Vertical
  }

  public enum Customization : byte { 
    Basic = 1, Advanced = 2, Special = 3 
  }

  public enum Movement : byte { 
    Leftward = 0, Rightward = 1, Downward = 2, Halted = 3
  };
}

