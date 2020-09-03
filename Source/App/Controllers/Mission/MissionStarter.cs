using System;

using UnityEngine;

/// <summary>
/// Classe responsável por armazenar informações da missão (nave escolhida, customizações)
/// </summary>
public class MissionStarter : MonoBehaviour {

  #region Variáveis

  public GameObject[] missionControllers;

  public static byte weaponCount, shieldStrength, engineStrength;
  public static string missionName;
  public static GameObject spaceship, missionController;

  #endregion

  /// <summary>
  /// Retorna o tipo de missão escolhido pelo jogador.
  /// Usar enum Missions aqui.
  /// </summary>
  /// 
  /// <returns>
  /// O tipo de missão escolhido
  /// </returns>
  public byte getMission () {
    return (byte) Enum.Parse(typeof(Enums.Missions), missionName);
  }

  /// <summary>
  /// Inicialização apenas
  /// </summary>
  private void Start () {
    missionController = missionControllers[getMission()];
    if (missionName.Contains("Defender")) {
      spaceship.AddComponent<PlayerSpecialMovementController>();
    } else {
      spaceship.AddComponent<PlayerMovementController>();
    }
    Instantiate(missionController);
  }
}
