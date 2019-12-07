using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerConstructor : SpaceshipConstructor {

  #region Vari�veis

  private int _score, _highScore;
  private Text scoreText, highScoreText;

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
      if (_score > _highScore) {
        highScore = _score;
      }
    }
  }

  public int highScore {
    get => _highScore;
    set {
      _highScore = value;
      PlayerPrefs.SetInt(Enums.Player.HighScore.ToString(), highScore);
    }
  }

  #endregion

  #region Meus m�todos

  /*
   * Provis�rio: salva nas prefer�ncias do jogador o highscore dele e depois atualiza o texto na tela
   */
  protected override void setUpScore () {
    scoreText = GameObject.FindGameObjectWithTag(Enums.Player.Score.ToString()).GetComponent<Text>();
    highScoreText = GameObject.FindGameObjectWithTag(Enums.Player.HighScore.ToString()).GetComponent<Text>();
    if (PlayerPrefs.HasKey(Enums.Player.HighScore.ToString()) == false) {
      PlayerPrefs.SetInt(Enums.Player.HighScore.ToString(), 0);
    }
    highScoreText.text = PlayerPrefs.GetInt(Enums.Player.HighScore.ToString()).ToString();
  }

  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.audioSource = GetComponent<AudioSource>();
    attackController.bulletsPerFire = SpaceshipCustomizationController.weaponCount;
    attackController.shootVelocity = 75;
  }

  protected override void setUpEnergy () {
    base.setUpEnergy();
    energyController.shieldSlider = GameObject.FindGameObjectWithTag(Enums.Tags.ShieldSlider.ToString()).GetComponent<Slider>();
    energyController.speedSlider = GameObject.FindGameObjectWithTag(Enums.Tags.SpeedSlider.ToString()).GetComponent<Slider>();
    energyController.weaponSlider = GameObject.FindGameObjectWithTag(Enums.Tags.WeaponSlider.ToString()).GetComponent<Slider>();
    energyController._shieldMultiplier = energyController.shieldSlider.value;
    energyController._speedMultiplier = energyController.speedSlider.value;
    energyController._weaponMultiplier = energyController.weaponSlider.value;
    energyController.step = 6;
    energyController.updateSpaceshipStatus();
  }

  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hpSlider = GameObject.FindGameObjectWithTag(Enums.Tags.RemainingHpSlider.ToString()).GetComponent<Slider>();
    lifeController.shieldSlider = GameObject.FindGameObjectWithTag(Enums.Tags.RemainingShieldSlider.ToString()).GetComponent<Slider>();
    lifeController.hpSlider.maxValue = lifeController.hp;
    lifeController.maxShield = lifeController.baseShield * (0.5f + SpaceshipCustomizationController.engineStrength / 2);
    lifeController.shield = lifeController.baseShield;
  }

  protected override void setUpMovement () {
    transform.position = new Vector3(0, -30, 0);
    movementController.baseSpeed = 0.5f + (SpaceshipCustomizationController.engineStrength / 2);
    movementController.move = movementController.normalMovement;
  }

  #endregion

}