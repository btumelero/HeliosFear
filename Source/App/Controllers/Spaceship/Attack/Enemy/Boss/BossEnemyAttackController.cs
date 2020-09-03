using Interfaces;

using UnityEngine;

/// <summary>
/// Classe responsável por controlar o comportamento de ataque geral de boss
/// </summary>
public abstract class BossEnemyAttackController : EnemyAttackController, ISpecialAttack {

  #region Variáveis

  /// <summary>
  /// O tiro especial do boss
  /// </summary>
  public GameObject specialBullet;

  /// <summary>
  /// Timer que controla o tempo entre disparos especiais
  /// </summary>
  public Timer specialShootTimer { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Para acessar os métodos de extensão da interface
  /// </summary>
  public IAttack iAttack { 
    get => this as IAttack; 
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Subclasses devem implementar o método especial de ataque do boss
  /// </summary>
  public abstract void specialAttack ();

  /// <summary>
  /// Inicializa o tiro especial e, caso setAsChild seja verdadeiro, coloca ele como filho do objeto que tem esse script, 
  /// para que assim ele se mova junto com a nave.
  /// </summary>
  /// 
  /// <param name="spawner">
  /// O objeto que disparou o tiro
  /// </param>
  /// 
  /// <param name="setAsChild">
  /// Se o tiro deve acompanhar o movimento da nave ou não
  /// </param>
  protected void instantiateBullet (Transform spawner, bool setAsChild) {
    if (spawner != null) {
      GameObject newSpecialBullet = Instantiate(specialBullet);
      if (setAsChild) {
        newSpecialBullet.transform.SetParent(gameObject.transform);
      }
      initializeBullet(newSpecialBullet, spawner);
      newSpecialBullet.transform.LookAt(newSpecialBullet.transform.position + spawner.up);
    }
  }

  #endregion

  #region Métodos da Unity

  

  #endregion
}
