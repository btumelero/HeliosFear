using System;
using UnityEngine;

public class Mission : MonoBehaviour {

  #region Variáveis

  public GameObject[] missionControllers;

  public static byte weaponCount, shieldStrength, engineStrength;
  public static string missionName;
  public static GameObject spaceship, missionController;

  #endregion

  public byte getMission () {
    return (byte) Enum.Parse(typeof(Enums.Missions), missionName);
  }


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
