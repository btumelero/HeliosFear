using Assets.Source.App.Data.Utils;
using Assets.Source.App.Utils.Interfaces.Builders;

using UnityEngine;

/// <summary>
/// Contém todas as structs referentes às naves do jogo.
/// </summary>
namespace Assets.Source.App.Data.Spaceship {

  /// <summary>
  /// Contém todos os valores referentes ao movimento das naves do jogo
  /// </summary>
  public struct MovementData : IData {

    #region Constantes

    public static readonly MovementData
      BOSS_ATTACKER = new MovementData() {
        baseSpeed = 10f,
        startingPosition = Vector3.zero,//
        specialPosition = Vector3.zero,//
      },
      BOSS_DEFENDER = new MovementData() {
        baseSpeed = 7.5f,
        movementTypeTimer = 15f,
        startingPosition = Position.screenTop,
        specialPosition = Position.offscreenTop,
      },
      BOSS_DODGER = new MovementData() {
        baseSpeed = 20f,
        movementTimer = 3f,
        movementTypeTimer = 15f,
        startingPosition = Vector3.zero,//
        specialPosition = Vector3.zero,//
      },
      ENEMY_ATTACKER = new MovementData() {
        movementTimer = 4f,
        baseSpeed = 125f,
      },
      ENEMY_DEFENDER = new MovementData() {
        movementTimer = 4.5f,
        baseSpeed = 100f,
      },
      ENEMY_DODGER = new MovementData() {
        movementTimer = 3f,
        baseSpeed = 200f,
      },
      ENEMY_NORMAL = new MovementData() {
        movementTimer = 3.5f,
        baseSpeed = 150f,
      },
      PLAYER_ATTACKER = new MovementData() {
        baseSpeed = 40f,
        minimumX = -26,
        maximumX = 26,
        minimumY = -34,
        maximumY = 36,
        startingPosition = Position.screenBottom,
      },
      PLAYER_DEFENDER = new MovementData() {
        baseSpeed = 35f,
        minimumX = -26,
        maximumX = 26,
        minimumY = -34,
        maximumY = 36,
        startingPosition = Position.screenBottom,
      },
      PLAYER_DODGER = new MovementData() {
        baseSpeed = 60f,
        minimumX = -28,
        maximumX = 28,
        minimumY = -36,
        maximumY = 38,
        startingPosition = Position.screenBottom,
      },
      PLAYER_NORMAL = new MovementData() {
        baseSpeed = 45f,
        minimumX = -28,
        maximumX = 28,
        minimumY = -35,
        maximumY = 37,
        startingPosition = Position.screenBottom,
      }
    ;

    #endregion

    #region Campos

    public float
      baseSpeed,
      movementTimer,
      movementTypeTimer
    ;

    public int
      minimumX,
      maximumX,
      minimumY,
      maximumY
    ;

    public Vector3
      startingPosition,
      specialPosition
    ;

    #endregion

    #region Construtores

    public MovementData (
      float baseSpeed,
      float movementTimerBaseTime,
      float movementTypeTimerBaseTime,
      int minimumX,
      int maximumX,
      int minimumY,
      int maximumY,
      Vector3 startingPosition,
      Vector3 specialPosition
    ) {
      this.baseSpeed = baseSpeed;
      this.movementTimer = movementTimerBaseTime;
      this.movementTypeTimer = movementTypeTimerBaseTime;
      this.minimumX = minimumX;
      this.maximumX = maximumX;
      this.minimumY = minimumY;
      this.maximumY = maximumY;
      this.startingPosition = startingPosition;
      this.specialPosition = specialPosition;
    }

    #endregion

  }
}
