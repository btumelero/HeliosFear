using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionController : MonoBehaviour {

  #region Variáveis

  protected HashSet<string> tagSet;
  protected LifeController lifeController;

  #endregion

  #region Métodos Nativos da Unity

  /*
   * Esse método executa sempre que um GameObject que tem um Collider marcado como Trigger
   * se choca com outro GameObject que também tem um Collider (não necessariamente marcado como Trigger).
   * Além disso, um dos dois precisa ter um RigidBody
   * 
   * Esse método gerencia as colisões do objeto tiver esse Script
   */
  protected virtual void OnTriggerEnter (Collider other) {
    lifeController = gameObject.GetComponentInParent<LifeController>();
    tagSet.Clear();
    tagSet.Add(gameObject.tag);
    tagSet.Add(other.gameObject.tag);
    if (isBulletCollision()) {
      onBulletCollision(other.gameObject);
    } else
    if (isCollision()) {
      onCollision(this.gameObject);
    }
  }

  /*
   * Inicialização apenas
   */
  protected virtual void Start () {
    tagSet = new HashSet<string>();
  }

  #endregion

  #region Meus Métodos

  /*
   * Deve retornar verdadeiro se o objeto que tem esse script se chocar contra outra nave ou escudo inimigo
   */
  protected abstract bool isCollision ();

  /*
   * Diminui a vida da nave sempre que houver uma colisão
   */
  protected virtual void onCollision (GameObject gameObject) {
    lifeController.shield--;
  }

  /*
   * Deve retornar verdadeiro se o objeto que tem esse script se chocar contra um tiro
   */
  protected abstract bool isBulletCollision ();

  /*
   * Deve chamar o método responsável pela colisão entre esse objeto e um tiro
   */
  protected abstract void onBulletCollision (GameObject bullet);

  #endregion
}
