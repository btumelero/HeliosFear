using System.Collections.Generic;
using System.Linq;

using Assets.Source.App.Controllers.Other;
using Assets.Source.App.Data.Mission;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;

using UnityEngine;

/// <summary>
/// Contém todas as classes responsáveis por controlar a interface do usuário
/// </summary>
namespace Assets.Source.App.UI {

  /// <summary>
  /// Classe responsável por gerenciar a customização da nave
  /// </summary>
  public class MenuDataGatherer : Menu {

    #region Campos

    /// <summary>
    /// Os prefabs das naves do jogador.
    /// </summary>
    public GameObject[] spaceshipsPrefabs;

    #endregion

    #region Meus Métodos

    #region MissionData

    /// <summary>
    /// Esse método é chamado ao clicar em um dos botões que definem a missão que será jogada
    /// </summary>
    public void missionButton () {
      MissionData.missionName = getSelectedButtonText().toEnum<Missions>();
    }

    #endregion

    #region PlayerData

    /// <summary>
    /// Esse método é chamado ao clicar em um dos botões que definem a nave do jogador
    /// </summary>
    public void spaceshipButton () {
      PlayerData.spaceship = spaceshipsPrefabs[(byte) getSelectedButtonText().toEnum<Spaceships>()];
    }

    public void customizationButton () {
      List<ButtonGroup> buttonGroups = GetComponentsInChildren<ButtonGroup>().OrderBy(group => group.name).ToList();
      PlayerData.engineStrength = buttonGroups[0].getClickedButton();
      PlayerData.shieldStrength = buttonGroups[1].getClickedButton();
      PlayerData.weaponCount = buttonGroups[2].getClickedButton();
    }

    #endregion

    /// <summary>
    /// Temporário: desbloqueia todas as conquistas
    /// </summary>
    public void cheatButton () {
      AchievementController.lockUnlock();
    }

    #endregion

  }
}