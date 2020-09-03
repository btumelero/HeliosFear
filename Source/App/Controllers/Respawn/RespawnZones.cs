using UnityEngine;

namespace Assets.Source.App.Controllers.Respawn {

  /// <summary>
  /// Classe responsável por gerenciar as zonas de respawn.
  /// </summary>
  public class RespawnZones : MonoBehaviour {

    #region Campos

    /// <summary>
    /// As zonas de respawn ao redor da tela.
    /// </summary>
    [HideInInspector] public BoxCollider[] zones;

    #endregion

    #region Propriedades

    /// <summary>
    /// Zona de respawn inferior.
    /// </summary>
    public BoxCollider bottom {
      get => zones[3];
    }

    /// <summary>
    /// Zona de respawn esquerda.
    /// </summary>
    public BoxCollider left {
      get => zones[2];
    }

    /// <summary>
    /// Zona de respawn direita.
    /// </summary>
    public BoxCollider right {
      get => zones[1];
    }

    /// <summary>
    /// Zona de respawn superior.
    /// </summary>
    public BoxCollider top {
      get => zones[0];
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Retorna uma zona de respawn aleatória.
    /// </summary>
    /// 
    /// <returns>
    /// Uma zona de respawn aleatória.
    /// </returns>
    public BoxCollider getRandomRespawnZone () {
      return zones[Random.Range(0, 4)];
    }

    #endregion

  }
}