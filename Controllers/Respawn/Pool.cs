using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class Pool : MonoBehaviour {

  #region Variáveis

  private static Vector3 offscreenPosition = new Vector3(60, 60, 60);
  private static readonly Dictionary<byte, Queue<GameObject>> pool =
    new Dictionary<byte, Queue<GameObject>>();

  #endregion

  #region Métodos da Unity

  /**
   * Start is called before the first frame update
   */
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

  public GameObject retrieve (byte enemy) {
    if (enemyPoolIsEmpty(enemy) == false) {
      pool[enemy].Peek().SetActive(true);
      return pool[enemy].Dequeue();
    }
    return null;
  }

  public static void store (byte enemy, GameObject spaceship) {
    spaceship.SetActive(false);
    spaceship.GetComponent<CommonEnemyConstructor>().reconstruct();
    spaceship.transform.position = offscreenPosition;
    pool[enemy].Enqueue(spaceship);
  }

  public bool enemyPoolIsEmpty (byte enemy) {
    return pool[enemy].Count == 0;
  }

  public bool enemyHasPool (byte enemy) {
    return pool.ContainsKey(enemy);
  }

  #endregion

}
