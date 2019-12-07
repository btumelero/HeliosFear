using System.Collections.Generic;
using UnityEngine;

/**
 * Controla o comportamento de colisões
 */
public abstract class CollisionController : MonoBehaviour {

  #region Variáveis

  /**
   * O set que vai conter as tags dos dois objetos que colidirem
   */
  protected List<string> tagList;

  /**
   * Referência do controlador de vida do objeto que tem esse script
   */
  protected LifeController colliderLifeController;

  #endregion

  #region Métodos Nativos da Unity

  /**
   * OnTriggerEnter is called when the GameObject collides with another GameObject.
   * 
   * Esse método gerencia as colisões do objeto tiver esse Script.
   * As tags são adicionadas no set e um método específico para cada tipo de colisão é chamado
   */
  protected virtual void OnTriggerEnter (Collider other) {
    other.transform.root.TryGetComponent(out LifeController life);
    colliderLifeController = life;
    tagList.Clear();
    tagList.Add(gameObject.tag);
    tagList.Add(other.gameObject.tag);
    if (isCollision()) {
      onCollision();
    }
  }

  /**
   * Start is called before the first frame update
   * 
   * Inicialização apenas
   */
  protected virtual void Start () {
    tagList = new List<string>();
  }

  #endregion

  #region Meus Métodos

  /**
   * Deve retornar verdadeiro se o objeto que tem esse script se chocar
   */
  protected abstract bool isCollision ();

  /**
   * Diminui a/o vida/escudo da nave sempre que houver uma colisão
   */
  protected abstract void onCollision ();

  protected bool compareCollidersTags (Enums.Tags playerTag, Enums.Tags enemyTag) {
    if (tagList.Contains(playerTag.ToString())) {
      tagList.Remove(playerTag.ToString());
      return tagList[0].Contains("Enemy") && ((tagList[0].EndsWith("Bullet") == false));
    } else
    if (tagList.Contains(enemyTag.ToString())) {
      tagList.Remove(enemyTag.ToString());
      return tagList[0].Contains("Player");
    }
    return false;
  }

  #endregion
}
