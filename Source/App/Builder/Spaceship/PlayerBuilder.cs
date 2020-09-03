using Assets.Source.App.Controllers.Spaceship.Attack;
using Assets.Source.App.Controllers.Spaceship.Energy;
using Assets.Source.App.Controllers.Spaceship.Life;
using Assets.Source.App.Controllers.Spaceship.Movement.Player;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.ScreenLimits;
using Assets.Source.App.Data.Spaceship;

using UnityEngine;
using UnityEngine.UI;
using Assets.Source.App.Data.Mission;
using Assets.Source.Experimental;

/// <summary>
/// Contém as classes responsáveis por construir as naves do jogo
/// </summary>
namespace Assets.Source.App.Builders.Spaceship {

  /// <summary>
  /// Classe responsável por construir as naves do jogador
  /// </summary>
  public class PlayerBuilder : SpaceshipBuilder {

    #region Propriedades

    /// <summary>
    /// Retorna o controlador de ataque do jogador
    /// </summary>
    protected new PlayerAttackController attackController =>
      (PlayerAttackController) _attackController
    ;

    /// <summary>
    /// Retorna o controlador de vida do jogador
    /// </summary>
    protected new PlayerEnergyController energyController =>
      (PlayerEnergyController) _energyController
    ;

    /// <summary>
    /// Retorna o controlador de energia do jogador
    /// </summary>
    protected new PlayerLifeController lifeController =>
      (PlayerLifeController) _lifeController
    ;

    /// <summary>
    /// Retorna o controlador de movimento do jogador
    /// </summary>
    protected new PlayerMovementController movementController =>
      (PlayerMovementController) _movementController
    ;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Inicializa o controlador de ataque do jogador
    /// </summary>
    /// 
    /// <param name="attackData">
    /// Os dados de ataque do jogador
    /// </param>
    public override void onBuild (AttackData attackData) {
      base.onBuild(attackData);
      attackController.score = new FieldWithAction<int>() {
        onValueChange = attackController.onScoreValueChange
      };
      attackController.highScore = new FieldWithAction<int>() {
        Value = PlayerPrefs.GetInt(Tags.HighScore.ToString()),
        onValueChange = attackController.onHighScoreValueChange
      };
      attackController.audioSource = objectToBuild.GetComponentInChildren<AudioSource>();
      attackController.scoreText = Game.findWithTag(Tags.Score).GetComponent<Text>();
      attackController.highScoreText = Game.findWithTag(Tags.HighScore).GetComponent<Text>();
      if (PlayerPrefs.HasKey(Tags.HighScore.ToString()) == false) {
        PlayerPrefs.SetInt(Tags.HighScore.ToString(), 0);
      }
      if (PlayerData.weaponCount - 2 >= 0) {
        attackController.weapons[1].gameObject.SetActive(true);
        attackController.weapons[2].gameObject.SetActive(true);
        PlayerData.weaponCount -= 2;
      }
      if (PlayerData.weaponCount - 1 >= 0) {
        attackController.weapons[0].gameObject.SetActive(true);
      }
      attackController.normalAttackCoroutine.play(attackController.normalAttack());
    }

    /// <summary>
    /// Inicializa o controlador de energia do jogador
    /// </summary>
    /// 
    /// <param name="energyData">
    /// Os dados de energia do jogador
    /// </param>
    public override void onBuild (EnergyData energyData) {
      base.onBuild(energyData);
      energyController.shieldSlider =
        Game.findWithTag(Tags.ShieldSlider).GetComponent<Slider>();
      energyController.speedSlider =
        Game.findWithTag(Tags.SpeedSlider).GetComponent<Slider>();
      energyController.weaponSlider =
        Game.findWithTag(Tags.WeaponSlider).GetComponent<Slider>();
      energyController.multipliers = new Multipliers(
        (slider) => energyController.onValueChange(slider.Value),
        energyController.shieldSlider.value,
        energyController.speedSlider.value,
        energyController.weaponSlider.value
      );
      energyController.step = 6;
    }

    /// <summary>
    /// Inicializa o controlador de vida do jogador
    /// </summary>
    /// 
    /// <param name="lifeData">
    /// Os dados de vida do jogador
    /// </param>
    public override void onBuild (LifeData lifeData) {
      base.onBuild(lifeData);
      lifeController.maxShield.onValueChange = lifeController.onMaxShieldValueChange;
      lifeController.hpSlider = Game.findWithTag(Tags.RemainingHpSlider
      ).GetComponent<Slider>();
      lifeController.shieldSlider = Game.findWithTag(Tags.RemainingShieldSlider
      ).GetComponent<Slider>();
    }

    /// <summary>
    /// Inicializa o controlador de movimento do jogador
    /// </summary>
    /// 
    /// <param name="movementData">
    /// Os dados de movimento do jogador
    /// </param>
    public override void onBuild (MovementData movementData) {
      base.onBuild(movementData);
      movementController.screenLimits = movementController.GetComponentInChildren<ScreenLimits>();
      if (MissionData.missionName.Equals("Tutorial") == false) {
        movementController.transform.position = new Vector3(0, -44, 0);
      }
    }

    #endregion

  }
}