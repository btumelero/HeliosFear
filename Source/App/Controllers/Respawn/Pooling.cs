using System.Collections.Generic;

using Assets.Source.App.Data.Utils;

using UnityEngine;

namespace Assets.Source.App.Controllers.Respawn {

  public class Pooling {

    #region Campos

    private static readonly Dictionary<string, Queue<GameObject>> pool =
      new Dictionary<string, Queue<GameObject>>() {
        {
          "Enemy Attacker",
          new Queue<GameObject>()
        },
        {
          "Enemy Defender",
          new Queue<GameObject>()
        },
        {
          "Enemy Dodger",
          new Queue<GameObject>()
        },
        {
          "Enemy Normal",
          new Queue<GameObject>()
        },
      };

    private GameObject newEnemy;

    #endregion

    #region Getters e Setters

    private GameObject get (GameObject spaceship) {
      pool.TryGetValue(spaceship.tag, out var enemies);
      return enemies?.Count > 0 ? pool[spaceship.tag].Dequeue() : null;
    }

    private static void put (GameObject spaceship) {
      pool[spaceship.tag].Enqueue(spaceship);
    }

    #endregion

    #region Meus Métodos

    public GameObject retrieve (GameObject enemy, Vector3 position) {
      if (newEnemy = get(enemy)) {
        newEnemy.SetActive(true);
        newEnemy.transform.position = position;
      }
      return newEnemy;
    }

    public static void store (GameObject enemy) {
      enemy.SetActive(false);
      enemy.transform.position = Position.poolingPosition;
      put(enemy);
    }

    #endregion

  }
}
