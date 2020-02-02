using System;
using System.Collections.Generic;

using Enums;

using UnityEngine;

/// <summary>
/// Classe responsável pela técnica de reaproveitamento de objetos usada para aumentar a performance.
/// </summary>
public class Pool : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// A posição para a qual os inimigos derrotados serão movidos.
  /// </summary>
  private static readonly Vector3 offscreenPosition = new Vector3(60, 60, 60);

  /// <summary>
  /// Dicionário contendo os tipos de inimigos como chave e as listas de inimigos armazenados como valor.
  /// Usar o enum Spaceships aqui
  /// </summary>
  private static readonly Dictionary<byte, Queue<GameObject>> pool =
    new Dictionary<byte, Queue<GameObject>>();

  #endregion

  #region Métodos da Unity

  /// <summary>
  /// Inicialização do dicionário.
  /// </summary>
  private void Start () {
    byte[] enemyTypes = (byte[]) Enum.GetValues(typeof(Spaceships));
    for (int i = 0; i < enemyTypes.Length; i++) {
      if (enemyHasPool(enemyTypes[i]) == false) {
        pool.Add(enemyTypes[i], new Queue<GameObject>());
      }
    }
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Retorna um inimigo ativo do tipo passado por parâmetro se existir um ou nulo se não existir.
  /// Usar o enum Spaceships aqui.
  /// </summary>
  /// 
  /// <param name="enemy">
  /// O inimigo a ser recuperado
  /// </param>
  /// 
  /// <returns>
  /// Um inimigo se existir um ou nulo se não existir
  /// </returns>
  public GameObject retrieve (byte enemy) {
    if (enemyPoolIsEmpty(enemy) == false) {
      pool[enemy].Peek().SetActive(true);
      return pool[enemy].Dequeue();
    }
    return null;
  }

  /// <summary>
  /// Armazena, desativa e move o inimigo passado por parâmetro para fora da tela.
  /// Usar o enum Spaceships aqui.
  /// </summary>
  /// 
  /// <param name="enemy">
  /// O tipo de inimigo a ser armazenado
  /// </param>
  /// 
  /// <param name="spaceship">
  /// A nave do inimigo a ser armazenada
  /// </param>
  public static void store (byte enemy, GameObject spaceship) {
    spaceship.SetActive(false);
    spaceship.GetComponent<CommonEnemyConstructor>().reconstruct();
    spaceship.transform.position = offscreenPosition;
    pool[enemy].Enqueue(spaceship);
  }

  /// <summary>
  /// Retorna verdadeiro se não há inimigos do tipo passado por parâmetro armazenados.
  /// Usar o enum Spaceships aqui.
  /// </summary>
  /// 
  /// <param name="enemy">
  /// O tipo de inimigo a checar se há armazenado
  /// </param>
  /// 
  /// <returns>
  /// Verdadeiro se não há inimigos armazenados
  /// </returns>
  public bool enemyPoolIsEmpty (byte enemy) {
    return pool[enemy].Count == 0;
  }

  /// <summary>
  /// Retorna verdadeiro se o inimigo passado por parâmetro já têm a sua lista para armazenamento.
  /// Usar o enum Spaceships aqui.
  /// </summary>
  /// 
  /// <param name="enemy">
  /// O tipo de inimigo a checar se tem pool
  /// </param>
  /// 
  /// <returns>
  /// Verdadeiro se o inimigo possui pool
  /// </returns>
  public bool enemyHasPool (byte enemy) {
    return pool.ContainsKey(enemy);
  }

  #endregion

}
