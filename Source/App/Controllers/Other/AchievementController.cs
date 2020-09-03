using System;
using Assets.Source.App.Utils.Enums;
using UnityEngine;

namespace Assets.Source.App.Controllers.Other{

  /// <summary>
  /// Classe responsável pelo gerenciamento de conquistas
  /// </summary>
  public class AchievementController : MonoBehaviour {

    #region Meus Métodos

    /// <summary>
    /// Retorna verdadeiro se a conquista foi desbloqueada
    /// </summary>
    /// 
    /// <param name="key">
    /// O nome da conquista a ser checada
    /// </param>
    /// 
    /// <returns>
    /// Verdadeiro se foi desbloqueada
    /// </returns>
    public static bool isUnlocked (string key) {
      return PlayerPrefs.HasKey(key) && Convert.ToBoolean(PlayerPrefs.GetInt(key));
    }

    /// <summary>
    /// Salva como bloqueado todas as conquistas ainda não salvadas
    /// </summary>
    /// 
    /// <param name="key">
    /// O nome da conquista
    /// </param>
    private void lockIfAbsent (string key) {
      if (PlayerPrefs.HasKey(key) == false) {
        PlayerPrefs.SetInt(key, 0);
      }
    }

    /// <summary>
    /// Trava/Destrava todas as conquistas
    /// </summary>
    public static void lockUnlock () {
      string[] achievements = Enum.GetNames(typeof(Achievement));
      for (int i = 0; i < achievements.Length; i++) {
        PlayerPrefs.SetInt(
          achievements[i],
          PlayerPrefs.GetInt(achievements[i]) == 0 ? 1 : 0
        );
      }
    }

    #endregion

    #region Métodos da Unity

    /// <summary>
    /// Inicializa as conquistas
    /// </summary>
    private void Start () {
      string[] achievements = Enum.GetNames(typeof(Achievement));
      for (int i = 0; i < achievements.Length; i++) {
        lockIfAbsent(achievements[i]);
      }
    }

    #endregion

  }
}
