/// <summary>
/// Classe responsável pelo comportamento de colisões com tiros
/// </summary>
public class BulletCollisionController : CollisionController {

  #region Variáveis

  /// <summary>
  /// O controlador do tiro
  /// </summary>
  public BulletController bulletController { get; set; }

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicialização apenas
  /// </summary>
  protected override void Start () {
    base.Start();
    bulletController = gameObject.GetComponentInParent<BulletController>();
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Retorna verdadeiro se houve uma colisão entre um tiro e uma nave da facção inimiga
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se for uma colisão tiro-nave inimiga ou tiro-escudo inimigo
  /// </returns>
  protected override bool isCollision () {
    return compareCollidersTags(Enums.Tags.FriendlyBullet, Enums.Tags.EnemyBullet);
  }

  /// <summary>
  /// Diminui vida/escudo da nave sempre que houver uma colisão
  /// </summary>
  protected override void onCollision () {
    if (tagList[0].Contains("Shield")) {
      bulletController.hitShield(colliderLifeController);
    } else {
      if (colliderLifeController != null) {
        if (colliderLifeController.shield <= 0) {
          bulletController.hitSpaceship(colliderLifeController);
        }
      }
    }
  }

  #endregion

}
