using System.Collections;
using System.Collections.Generic;

using Assets.Source.App.Data.Utils;
using Assets.Source.App.Utils.Enums;
using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Interfaces.Movements;

using UnityEngine;

namespace Assets.Source.App.Controllers.Spaceship.Movement.Enemy.Boss {

  /// <summary>
  /// Classe responsável por controlar os movimentos do boss focado em velocidade
  /// </summary>
  public class BossEnemyDodgerMovementController : BossEnemyMovementController {

    #region Campos

    #region Movimentação Especial

    /// <summary>
    /// Guarda a rotação da nave quando ela está de frente para a câmera
    /// </summary>
    public Quaternion specialRotation;

    /// <summary>
    /// O objeto que representa a circunferência sobre a qual a nave gira
    /// </summary>
    public GameObject orbit;

    /// <summary>
    /// Velocidade de rotação da nave em torno de si mesma
    /// </summary>
    public float rotationSpeed;

    /// <summary>
    /// Velocidade de rotação em torno do centro da tela
    /// </summary>
    public float orbitalSpeed;

    #endregion

    #region Movimentação Normal

    /// <summary>
    /// A velocidade do boss durante a interpolação esférica
    /// </summary>
    private float slerpSpeed;

    /// <summary>
    /// A fração da esfera já percorrida
    /// </summary>
    private float fractionTravelled;

    /// <summary>
    /// A próxima posição para a qual o boss irá interpolar
    /// </summary>
    private Vector3? slerpFinalPosition;

    /// <summary>
    /// A posição da qual o boss irá interpolar
    /// </summary>
    private Vector3 slerpStartingPosition;

    /// <summary>
    /// A área pela qual o boss vai se mover
    /// </summary>
    [HideInInspector] public BoxCollider movementZone;

    #endregion

    #region Fade

    /// <summary>
    /// Os renderizadores da nave do boss
    /// </summary>
    [HideInInspector] public List<Renderer> spaceshipParts;

    #endregion

    #endregion

    #region Minhas Rotinas

    /// <summary>
    /// Faz o boss se mover em arcos para pontos aleatórios da tela
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    public override IEnumerator normalMovement () {
      while (true) {
        yield return new WaitForFixedUpdate();
        if (slerpFinalPosition == null) {
          prepareForNextIteration();
        }
        if (spaceshipReachedDestination() == false) {
          slerpToDestination();
        } else {
          slerpFinalPosition = null;
          yield return new WaitForSeconds(movementTimer);
        }
      }
    }


    /// <summary>
    /// Movimento de Translação e Rotação
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    public override IEnumerator specialMovement () {
      Vector3 forward = Vector3.forward;
      while (true) {
        yield return new WaitForFixedUpdate();
        gameObject.transform.Rotate(
          eulers: forward * rotationSpeed * Time.fixedDeltaTime,
          relativeTo: Space.World
        );
        orbit.transform.Rotate(
          eulers: forward * orbitalSpeed * Time.fixedDeltaTime,
          relativeTo: Space.Self
        );
      }
    }

    /// <summary>
    /// Faz o boss alternar entre os dois tipos de movimentação
    /// </summary>
    /// 
    /// <returns>
    /// Um IEnumerator que permite iniciar essa rotina
    /// </returns>
    public override IEnumerator switchMovements (IEnumerator previousCoroutine) {
      string
        previousMovement = previousCoroutine.ToString(),
        normalMovement = this.normalMovement().ToString()
      ;
      while (true) {
        yield return new WaitForSeconds(movementTypeTimer);
        yield return new WaitForFixedUpdate();
        if (previousMovement.Equals(normalMovement)) {
          if (specialPosition.HasValue == false) {
            nextSpecialPosition();
          }
          switchToSpecialMovement();
        } else {
          switchToNormalMovement();
        }
      }
    }

    #endregion

    #region Meus métodos

    #region Movimentação Normal

    /// <summary>
    /// Define a próxima posição especial do boss na tela. 
    /// É o centro da tela + offset de 2.5f para esquerda/direita/cima.
    /// </summary>
    private void nextSpecialPosition () {
      specialPosition =
        transform.position.x >= -10 && transform.position.x <= 10 ?
          new Vector3(0, 2.5f)
          :
          new Vector3(Mathf.Sign(transform.position.x) * 2.5f, 0)
      ;
    }

    /// <summary>
    /// Atualiza variáveis para o próximo cálculo
    /// </summary>
    private void prepareForNextIteration () {
      slerpStartingPosition = gameObject.transform.position;
      slerpFinalPosition = movementZone.getRandomPointInside();
      fractionTravelled = 0;
      slerpSpeed = Mathf.Clamp(
        value: Time.fixedDeltaTime / Vector3.Distance(
          slerpStartingPosition.normalized, slerpFinalPosition.Value.normalized
        ),
        min: 0.01f,
        max: 0.1f
      );
    }

    /// <summary>
    /// Retorna verdadeiro se o boss chegou ao destino
    /// </summary>
    /// 
    /// <returns>
    /// Verdadeiro se a distância entre a posição atual e o destino for menor que 0.1f
    /// </returns>
    private bool spaceshipReachedDestination () {
      return Vector3.Distance(gameObject.transform.position, slerpFinalPosition.Value) < 0.1f;
    }

    /// <summary>
    /// Interpola esfericamente para o destino
    /// </summary>
    private void slerpToDestination () {
      fractionTravelled += slerpSpeed;
      gameObject.transform.position = Vector3.Slerp(
        slerpStartingPosition,
        slerpFinalPosition.Value,
        fractionTravelled
      );
    }

    #endregion

    #region Transição para a movimentação normal

    /// <summary>
    /// Faz a nave retornar para a movimentação normal
    /// </summary>
    private void switchToNormalMovement () {
      leaveOrbit();
      resetSpaceshipTransform();
      StartCoroutine(fade(Fade.Out));
      if (this.positionAndRotationEquals(Position.screenCenter, Rotation.zero)) {
        movementCoroutine.play(normalMovement());
      }
    }

    /// <summary>
    /// Separa o gameObject orbit do gameObject spaceship
    /// </summary>
    private void leaveOrbit () {
      if (gameObject.transform.parent != null) {
        gameObject.transform.SetParent(null);
        orbit.transform.rotation = Rotation.zero;
      }
    }

    /// <summary>
    /// Retorna para o centro da tela e reseta a rotação da nave
    /// </summary>
    private void resetSpaceshipTransform () {
      this.moveTowards(Position.screenCenter, actualSpeed);
      this.rotateTowards(Rotation.zero, actualSpeed);
    }

    #endregion

    #region Transição para a movimentação especial

    /// <summary>
    /// A nave terá velocidade de rotação e translação diferentes 
    /// a cada vez que ela executar a movimentação especial
    /// para evitar o aparecimento de padrões que tornem a dificuldade menor 
    /// depois de serem identificados pelo jogador
    /// </summary>
    private void switchToSpecialMovement () {
      prepareSpaceshipTransform();
      StartCoroutine(fade(Fade.In));
      if (this.positionAndRotationEquals(specialPosition.Value, specialRotation)) {
        specialPosition = null;
        enterOrbit();
        movementCoroutine.play(specialMovement());
      }
    }

    /// <summary>
    /// Move a nave para o centro da tela e aponta a frente da nave para a câmera.
    /// </summary>
    private void prepareSpaceshipTransform () {
      this.moveTowards(specialPosition.Value, actualSpeed);
      this.rotateTowards(specialRotation, actualSpeed);
    }

    /// <summary>
    /// Junta o gameObject orbit com o gameObject spaceship e 
    /// dá uma velocidade aleatória para rotação e translação
    /// </summary>
    private void enterOrbit () {
      transform.rotation = Rotation.facingScreen;
      transform.SetParent(orbit.transform);
      orbitalSpeed = Random.Range(100, 200);
      rotationSpeed = Random.Range(400, 600);
    }

    #endregion

    #region Auxiliares

    /// <summary>
    /// Causa uma transição de transparência gradual
    /// </summary>
    /// 
    /// <param name="fade">
    /// Fade.IN para aumentar a transparência e Fade.OUT para diminuir
    /// </param>
    private IEnumerator fade (Fade fade) {
      Color color = Color.clear;
      do {
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < spaceshipParts.Count; i++) {
          color = spaceshipParts[i].material.color;
          color.a = Mathf.Clamp(
            value: color.a + (Time.deltaTime * (int) fade),
            min: 0,
            max: 1
          );
          spaceshipParts[i].material.color = color;
        }
      } while (color.a == 0 || color.a == 1);
    }

    #endregion

    #endregion

  }
}
