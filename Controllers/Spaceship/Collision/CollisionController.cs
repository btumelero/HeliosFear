using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Controla o comportamento de colisões
/// </summary>
public abstract class CollisionController : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// A lista que vai conter as tags dos objetos que colidirem
  /// </summary>
  protected List<string> tagList;

  /// <summary>
  /// Referência do controlador de vida do objeto que tem esse script
  /// </summary>
  protected LifeController colliderLifeController;

  #endregion

  #region Métodos Nativos da Unity

  /// <summary>
  /// Esse método gerencia as colisões do objeto tiver esse Script.
  /// As tags são adicionadas na lista e um método específico para cada tipo de colisão é chamado
  /// </summary>
  /// 
  /// <param name="other">
  /// O objeto que colidiu com o objeto que tem esse script
  /// </param>
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

  /// <summary>
  /// Inicialização apenas
  /// </summary>
  protected virtual void Start () {
    tagList = new List<string>();
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Deve retornar verdadeiro se o objeto que tem esse script se chocar
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se o objeto que tem esse script se chocou
  /// </returns>
  protected abstract bool isCollision ();

  /// <summary>
  /// Deve dar dano sempre que houver uma colisão
  /// </summary>
  protected abstract void onCollision ();

  /// <summary>
  /// Serve tanto para checar colisões do player quanto dos inimigos.
  /// A classe que controla colisões com escudos deve passar a tag do escudo do jogador e do inimigo, por exemplo,
  /// para comparar com as que estão na lista para saber se é uma colisão que aquela classe deve tratar ou não.
  /// </summary>
  /// 
  /// <param name="playerTag">
  /// A tag da parte da nave do jogador que deve ser checada
  /// </param>
  /// 
  /// <param name="enemyTag">
  /// A tag da parte da nave do inimigo que deve ser checada
  /// </param>
  /// 
  /// <returns>
  /// Verdadeiro se é uma colisão válida
  /// </returns>
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
