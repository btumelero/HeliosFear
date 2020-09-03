using Extensions;

using Interfaces.Movements;

using UnityEngine;

/// <summary>
/// Classe responsável por controlar os movimentos do boss focado em velocidade
/// </summary>
public class BossEnemyDodgerMovementController : BossEnemyMovementController, ISpecialMovement {

  #region Variáveis

  /// <summary>
  /// A posição especial da nave na tela.
  /// Centro da tela + deslocamento de 2.5 para a esquerda, direita ou cima.
  /// </summary>
  public Vector3 _specialPosition;

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

  /// <summary>
  /// A área pela qual o boss vai se mover
  /// </summary>
  public BoxCollider movementZone {get;set;}

  /// <summary>
  /// Timer que controla a movimentação normal do boss
  /// </summary>
  public Timer movementTimer { get; set; }
  #endregion


  public Vector3 specialPosition {
    get => _specialPosition;
  }

  #region Meus métodos

  /// <summary>
  /// 
  /// </summary>
  public override void normalMovement () {
    if (movementTypeTimer.timeIsUp()) {
      _specialPosition =
         transform.position.x >= -10 && transform.position.x <= 10 ?
          new Vector3(0, 2.5f, 0)
          :
          new Vector3(Mathf.Sign(transform.position.x) * 2.5f, 0, 0)
      ;
      move = switchToSpecialMovement;
    } else {
      if (movementTimer.timeIsUp()) {
        spaceship.transform.position = movementZone.bounds.getRandomPointInBounds();
        movementTimer.restart();
      }
    }
  }

  /// <summary>
  /// Movimento de Translação e Rotação
  /// </summary>
  public void specialMovement () {
    if (movementTypeTimer.timeIsUp()) {
      move = switchToNormalMovement;
    } else {
      transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime, Space.World);
      orbit.transform.Rotate(Vector3.forward * orbitalSpeed * Time.fixedDeltaTime, Space.Self);
    }
  }

  /// <summary>
  /// Retorna para o centro da tela e reseta a rotação da nave
  /// </summary>
  public void switchToNormalMovement () {
    if (transform.parent != null) {
      transform.SetParent(null);
      orbit.transform.rotation = Quaternion.identity;
    }
    spaceship.moveTowards(Vector3.zero, actualSpeed);
    spaceship.rotateTowards(Quaternion.identity, actualSpeed);
    if (spaceship.isAt(Vector3.zero) && spaceship.rotationIsZero()) {
      movementTypeTimer.restart();
      move = normalMovement;
    }
  }

  /// <summary>
  /// Move a nave para o centro da tela e aponta a frente da nave para a câmera.
  /// A nave terá velocidade de rotação e translação diferentes a cada vez que ela executar a movimentação especial
  /// para evitar o aparecimento de padrões que tornem a dificuldade menor depois de serem identificados pelo jogador
  /// </summary>
  public void switchToSpecialMovement () {
    spaceship.moveTowards(specialPosition, actualSpeed);
    spaceship.rotateTowards(specialRotation, actualSpeed);
    if (spaceship.isAt(specialPosition) && transform.rotation.eulerAngles.Equals(specialRotation.eulerAngles)) {
      transform.rotation = Quaternion.Euler(90, 90, 90);
      transform.SetParent(orbit.transform);
      orbitalSpeed = Random.Range(100, 200);
      rotationSpeed = Random.Range(400, 600);
      movementTypeTimer.restart();
      move = specialMovement;
    }
  }

  #endregion
}
