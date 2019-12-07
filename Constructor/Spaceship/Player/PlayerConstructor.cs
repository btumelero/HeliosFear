using UnityEngine;
using UnityEngine.UI;

/**
 * Responsável pelas inicializações de variáveis relacionadas à nave do jogador.
 */
public abstract class PlayerConstructor : SpaceshipConstructor {

  #region Getters e Setters

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected PlayerAttackController attackController {
    get => (PlayerAttackController) _attackController;
    set => _attackController = value;
  }

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected PlayerEnergyController energyController {
    get => (PlayerEnergyController) _energyController;
    set => _energyController = value;
  }

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected PlayerLifeController lifeController {
    get => (PlayerLifeController) _lifeController;
    set => _lifeController = value;
  }

  /**
   * Get que converte o controlador abstrato em um controlador concreto
   * para evitar ter que fazer conversões pra todo lado
   */
  protected PlayerMovementController movementController {
    get => (PlayerMovementController) _movementController;
    set => _movementController = value;
  }

  #endregion

  #region Meus métodos

  /**
   * Inicializa o ataque
   */
  protected override void setUpAttack () {
    base.setUpAttack();
    attackController.attack = attackController.normalAttack;
    attackController.audioSource = GetComponent<AudioSource>();
    attackController.shootVelocity = 75;
    if (Mission.weaponCount - 2 >= 0) {
      attackController.weapons[1].gameObject.SetActive(true);
      attackController.weapons[2].gameObject.SetActive(true);
    }
    if (Mission.weaponCount - 1 >= 0) {
      attackController.weapons[0].gameObject.SetActive(true);
    }
  }

  /**
   * Inicializa a energia
   */
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

  /**
   * Inicializa a vida
   */
  protected override void setUpLife () {
    base.setUpLife();
    lifeController.hpSlider = GameObject.FindGameObjectWithTag(Enums.Tags.RemainingHpSlider.ToString()).GetComponent<Slider>();
    lifeController.shieldSlider = GameObject.FindGameObjectWithTag(Enums.Tags.RemainingShieldSlider.ToString()).GetComponent<Slider>();
    lifeController.hpSlider.maxValue = lifeController.hp;
    lifeController.maxShield = lifeController.baseShield * (0.5f + Mission.engineStrength / 2);
    lifeController.shield = lifeController.baseShield;
  }

  /**
   * Inicializa o movimento
   */
  protected override void setUpMovement () {
    movementController._baseSpeed = 0.75f + (Mission.engineStrength / 4);
    movementController._startingPosition = new Vector3(0, -30, 0);
    if (Mission.missionName.Equals("Tutorial")) {
      movementController.move = movementController.normalMovement;
      transform.position = Vector3.zero;
    } else {
      transform.position = new Vector3(0, -44, 0);
    }
  }

  /**
   * Inicializa o score
   */
  protected override void setUpScore () {
    attackController.scoreText = GameObject.FindGameObjectWithTag(Enums.Player.Score.ToString()).GetComponent<Text>();
    attackController.highScoreText = GameObject.FindGameObjectWithTag(Enums.Player.HighScore.ToString()).GetComponent<Text>();
    if (PlayerPrefs.HasKey(Enums.Player.HighScore.ToString()) == false) {
      PlayerPrefs.SetInt(Enums.Player.HighScore.ToString(), 0);
    }
    attackController.highScoreText.text = PlayerPrefs.GetInt(Enums.Player.HighScore.ToString()).ToString();
  }

  #endregion

}