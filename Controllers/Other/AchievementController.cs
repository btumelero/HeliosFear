using System;
using UnityEngine;

public class AchievementController : MonoBehaviour {

  #region Meus Métodos

  public static bool isUnlocked (string key) {
    return PlayerPrefs.HasKey(key) ? Convert.ToBoolean(PlayerPrefs.GetInt(key)) : false;
  }

  private void lockIfAbsent (string key) {
    if (PlayerPrefs.HasKey(key) == false) {
      PlayerPrefs.SetInt(key, 0);
    }
  }

  public static void lockUnlock () {
    string[] achievements = Enum.GetNames(typeof(Enums.Achievement));
    for (int i = 0; i < achievements.Length; i++) {
      PlayerPrefs.SetInt(
        achievements[i],
        Convert.ToInt32(
          !Convert.ToBoolean(
            PlayerPrefs.GetInt(
              achievements[i]
            )
          )
        )
      );
    }
  }

  #endregion

  #region Métodos da Unity

  private void Start () {
    string[] achievements = Enum.GetNames(typeof(Enums.Achievement));
    for (int i = 0; i < achievements.Length; i++) {
      lockIfAbsent(achievements[i]);
    }
  }

  #endregion

}
