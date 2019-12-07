using UnityEngine;

public class RespawnZone : MonoBehaviour {

  #region Variáveis

  public BoxCollider[] _zones { get; set; }

  #endregion

  #region Getters e Setters

  public BoxCollider bottom {
    get => _zones[3];
  }

  public BoxCollider left {
    get => _zones[2];
  }

  public BoxCollider right {
    get => _zones[1];
  }

  public BoxCollider top {
    get => _zones[0];
  }

  #endregion

  #region Meus Métodos

  public Vector3 getRandomPointInBounds (Bounds bounds) {
    return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        0
    );
  }

  public BoxCollider getRandomRespawnZone () {
    return _zones[Random.Range(0, 4)];
  }

  #endregion

}