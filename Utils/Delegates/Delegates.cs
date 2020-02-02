/// <summary>
/// Contém os Delegates usados no projeto
/// </summary>
namespace Delegates {

  /// <summary>
  /// Responsável pela movimentação da nave
  /// </summary>
  public delegate void MovementType ();

  /// <summary>
  /// Responsável pelo estágio da missão
  /// </summary>
  public delegate void MissionStage ();

  /// <summary>
  /// Responsável pelo ataque da nave
  /// </summary>
  public delegate void AttackType ();

  /// <summary>
  /// Responsável pelo respawn dos inimigos
  /// </summary>
  public delegate void RespawnType ();

}
