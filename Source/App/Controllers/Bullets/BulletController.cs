using Assets.Source.App.Controllers.Spaceship.Life;

using UnityEngine;

namespace Assets.Source.App.Controllers.Bullets {

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
    /// O corpo da bala
    /// </summary>
    protected Rigidbody bulletBody;

    /// <summary>
    /// O dano que o tiro vai causar
    /// </summary>
    public float shootPower;

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Dá dano no objeto que for acertado por esse tiro.
    /// Se o objeto estiver com o escudo zerado, o dano é transferido para o hp.
    /// </summary>
    /// 
    /// <param name="lifeController">
    /// O controlador da vida do objeto acertado
    /// </param>
    public virtual void hit (LifeController lifeController) {
      lifeController.shield.Value -= shootPower;
    }

    /// <summary>
    /// Mostra um efeito de "explosão". Usado quando o tiro acerta algo.
    /// </summary>
    protected virtual void showEffect () {
      Instantiate(particleEffect, transform.position, transform.rotation);
    }

    /// <summary>
    /// Inicializa o tiro, colocando-o em posição e dando a potência adequada
    /// </summary>
    /// 
    /// <param name="shootPower">
    /// O dano do tiro a ser disparado
    /// </param>
    /// 
    /// <param name="shootingPosition">
    /// A posição da arma que disparou o tiro
    /// </param>
    public void initializeBullet (Transform shootingPosition, float shootPower) {
      bulletBody = gameObject.GetComponent<Rigidbody>();
      transform.position = shootingPosition.position;
      this.shootPower = shootPower;
    }

    /// <summary>
    /// Rotaciona o tiro na direção passada por parâmetro
    /// </summary>
    /// 
    /// <param name="direction">
    /// A direção em que o tiro deve ser disparado.
    /// </param>
    public virtual void rotateBullet (Vector3 direction) {
      transform.LookAt(transform.position + direction);
    }

    #endregion

  }
}
