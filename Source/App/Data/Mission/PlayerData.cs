using Assets.Source.App.Utils.Interfaces.Builders;

using UnityEngine;

/// <summary>
/// Contém todas as structs referentes às missões do jogo.
/// </summary>
namespace Assets.Source.App.Data.Mission {

  /// <summary>
  /// Contém todos os valores referentes ao jogador
  /// </summary>
  public struct PlayerData : IData {

    #region Constantes

    public static readonly PlayerData BOSS_ATTACKER;
    public static readonly PlayerData BOSS_DEFENDER;
    public static readonly PlayerData BOSS_DODGER;
    public static readonly PlayerData SURVIVAL;

    #endregion

    #region Variáveis Estáticas

    /// <summary>
    /// O número de armas da nave do jogador (1, 2, 3)
    /// </summary>
    public static byte weaponCount = 1;

    /// <summary>
    /// A força do escudo da nave do jogador (1, 2, 3)
    /// </summary>
    public static byte shieldStrength = 1;

    /// <summary>
    /// A força do motor da nave do jogador (1, 2, 3)
    /// </summary>
    public static byte engineStrength = 1;

    /// <summary>
    /// A nave escolhida pelo jogador
    /// </summary>
    public static GameObject spaceship;

    #endregion

    #region Variáveis

    #endregion

    #region Construtores

    #endregion

  }

}