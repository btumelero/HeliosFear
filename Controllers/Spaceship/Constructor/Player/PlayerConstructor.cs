using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerConstructor : SpaceshipConstructor {

  #region Variáveis

  private int _score, _highscore;
  private Text scoreText, highscoreText;

  #endregion

  #region Getters e Setters

  protected PlayerAttackController attackController {
    get => (PlayerAttackController) _attackController;
    set => _attackController = value;
  }

  protected PlayerEnergyController energyController {
    get => (PlayerEnergyController) _energyController;
    set => _energyController = value;  
  }

  protected PlayerLifeController lifeController {
    get => (PlayerLifeController) _lifeController;
    set => _lifeController = value;
  }

  protected PlayerMovementController movementController {
    get => (PlayerMovementController) _movementController;
    set => _movementController = value;
  }

  public int score {
    get => _score;
    set {
      _score = value;
      scoreText.text = score.ToString();
      if (_score > _highscore) {
        highscore = _score;
      }
    }
  }

  public int highscore {
    get => _highscore;
    set {
      _highscore = value;
      PlayerPrefs.SetInt("HighScore", highscore);
    }
  }

  #endregion

  #region Métodos da Unity


  #endregion

  #region Meus métodos

  /*
   * Provisório: salva nas preferências do jogador o highscore dele e depois atualiza o texto na tela
   */
  protected override void setUpScore () {
    scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    highscoreText = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>();
    if (PlayerPrefs.HasKey("HighScore") == false) {
      PlayerPrefs.SetInt("HighScore", 0);
    }
    highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
  }

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.audioSource = GetComponent<AudioSource>();
    attackController.bulletsPerFire = 1;
    attackController.shootVelocity = 75;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.shieldSlider = GameObject.FindGameObjectWithTag("ShieldSlider").GetComponent<Slider>();
    energyController.speedSlider = GameObject.FindGameObjectWithTag("SpeedSlider").GetComponent<Slider>();
    energyController.weaponSlider = GameObject.FindGameObjectWithTag("WeaponSlider").GetComponent<Slider>();
    energyController._shieldMultiplier = energyController.shieldSlider.value;
    energyController._speedMultiplier = energyController.speedSlider.value;
    energyController._weaponMultiplier = energyController.weaponSlider.value;
    energyController.step = 6;
    energyController.updateSpaceshipStatus();
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hpSlider = GameObject.FindGameObjectWithTag("RemainingHpSlider").GetComponent<Slider>();
    lifeController.shieldSlider = GameObject.FindGameObjectWithTag("RemainingShieldSlider").GetComponent<Slider>();
    lifeController.hpSlider.maxValue = lifeController.hp;
    lifeController.maxShield = lifeController.baseShield;
    lifeController.shield = lifeController.baseShield;
  }

  #endregion

}