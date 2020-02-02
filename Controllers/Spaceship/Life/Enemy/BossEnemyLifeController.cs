/// <summary>
/// Classe responsável por controlar a vida de boss
/// </summary>
public class BossEnemyLifeController : EnemyLifeController {

  #region Meus Métodos

  /// <summary>
  /// Destrói a nave caso ela esteja morta.
  /// Isso é feito aqui para evitar que a nave seja destruída antes que outra parte do código tente modificar alguma coisa
  /// </summary>
  protected override void Update () {
    base.Update();
    if (dead) {
      Destroy(gameObject);
    }
  }

  #endregion

}
