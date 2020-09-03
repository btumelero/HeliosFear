using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar as zonas de respawn.
/// </summary>
public class RespawnZones : MonoBehaviour {

  #region Variáveis

  /// <summary>
  /// As zonas de respawn ao redor da tela.
  /// </summary>
  public BoxCollider[] _zones { get; set; }

  #endregion

  #region Getters e Setters

  /// <summary>
  /// Zona de respawn inferior.
  /// </summary>
  public BoxCollider bottom {
    get => _zones[3];
  }

  /// <summary>
  /// Zona de respawn esquerda.
  /// </summary>
  public BoxCollider left {
    get => _zones[2];
  }

  /// <summary>
  /// Zona de respawn direita.
  /// </summary>
  public BoxCollider right {
    get => _zones[1];
  }

  /// <summary>
  /// Zona de respawn superior.
  /// </summary>
  public BoxCollider top {
    get => _zones[0];
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Retorna uma zona de respawn aleatória.
  /// </summary>
  /// <returns></returns>
  public BoxCollider getRandomRespawnZone () {
    return _zones[Random.Range(0, 4)];
  }

  #endregion

}