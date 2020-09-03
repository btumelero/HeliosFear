namespace Assets.Source.App.Controllers.Mission.BossMission {

  /// <summary>
  /// Classe responsável por gerenciar a missão contra o boss focado em velocidade
  /// </summary>
  public class BossDodgerMissionController : BossMissionController {

    #region Meus Métodos

    /// <summary>
    /// Atira um tiro para baixo quando está se movendo em arcos pela tela e
    /// e atira dois tiros em direções opostas enquanto esta girando em torno do centro da tela.
    /// Os dois tiros têm tempo randômico entre disparos para tornar imprevisível.
    /// Além disso, não atira enquanto está alternando entre as formas de movimentação e
    /// fica invulnerável sempre que não estiver se movendo em arcos pela tela.
    /// </summary>
    public override void updateBoss () {
      if (
        bossMovement.movementCoroutine.isPlaying(bossMovement.normalMovement()) &&
        bossAttack.normalAttackCoroutine.isPlaying(bossAttack.normalAttack()) == false
      ) {
        bossAttack.specialAttackCoroutine.stop();
        bossAttack.normalAttackCoroutine.play(bossAttack.normalAttack());
      } else {
        if (
          bossMovement.movementCoroutine.isPlaying(bossMovement.specialMovement()) &&
          bossAttack.specialAttackCoroutine.isPlaying(bossAttack.specialAttack()) == false
        ) {
          bossAttack.normalAttackCoroutine.stop();
          bossAttack.specialAttackCoroutine.play(bossAttack.specialAttack());
        }
      }
      bossLife.vulnerable.Value = bossMovement.movementCoroutine.isPlaying(bossMovement.normalMovement());
    }

    public override void updatePlayer () {

    }

    public override void updateOthers () {

    }

    #endregion

  }
}
