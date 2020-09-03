using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar a missão contra o boss focado em velocidade
/// </summary>
public class BossDodgerMissionController : BossMissionController {

  #region Variáveis

  /// <summary>
  /// O renderizador da nave do boss
  /// </summary>
  public Renderer spaceship { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Controlador de movimentos do Boss
  /// </summary>
  public new BossEnemyDodgerMovementController bossMovementController {
    get => (BossEnemyDodgerMovementController) _bossEnemyMovementController;
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Causa uma transição de transparência gradual
  /// </summary>
  /// 
  /// <param name="value">
  /// True para FadeIn, False para FadeOut
  /// </param>
  public void fade (bool value) {
    Color color = spaceship.material.color;
    color.a = Mathf.Clamp(color.a + (Time.deltaTime * (value ? -1 : 1)), 0, 1);
    spaceship.material.color = color;
  }

  /// <summary>
  /// Atira normalmente quando está se movendo normalmente e atira de forma especial ao se mover de forma especial.
  /// Forma de atirar especial tem tempo randômico entre disparos para tornar imprevisível.
  /// </summary>
  public override void updateBoss () {
    if (bossMovementController.move == bossMovementController.switchToNormalMovement) {
      fade(false);
    } else if (bossMovementController.move == bossMovementController.switchToSpecialMovement) {
      fade(true);
    } else if (bossMovementController.move == bossMovementController.specialMovement) {
      bossAttackController.attack = bossAttackController.specialAttack;
    } else if (bossMovementController.move == bossMovementController.normalMovement) {
      bossAttackController.attack = bossAttackController.normalAttack;
    }
  }

  public override void updatePlayer () {

  }

  public override void updateOthers () {

  }

  #endregion

}
