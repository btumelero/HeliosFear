using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar tiros
/// </summary>
public abstract class BulletController : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// O efeito exibido ao acertar um tiro
  /// </summary>
  public GameObject particleEffect;

  /// <summary>
  /// A potência do tiro
  /// </summary>
  public float shootPower;

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Dá dano na nave
  /// </summary>
  /// 
  /// <param name="lifeController">
  /// O controlador de vida da nave
  /// </param>
  public virtual void hitSpaceship (LifeController lifeController) {
    lifeController.hp -= shootPower;
  }

  /// <summary>
  /// Dá dano no escudo
  /// </summary>
  /// 
  /// <param name="lifeController">
  /// O controlador de vida da nave
  /// </param>
  public virtual void hitShield (LifeController lifeController) {
    lifeController.shield -= shootPower;
  }

  /// <summary>
  /// Mostra um efeito
  /// </summary>
  protected virtual void showEffect () {
    Instantiate(particleEffect, transform.position, transform.rotation);
  }

  #endregion
}
