﻿using Interfaces;

using UnityEngine;

/// <summary>
/// Contém os métodos de extensão do projeto
/// </summary>
namespace Extensions {

  /// <summary>
  /// Extensões da interface ISpecialAttack
  /// </summary>
  public static class IAttackExtension {

    /// <summary>
    /// Cria um vetor normalizado com o ângulo em que o tiro deve ser disparado
    /// </summary>
    /// 
    /// <param name="attack">
    /// O objeto que irá atacar (esse objeto)
    /// </param>
    /// 
    /// <param name="shooter">
    /// O corpo do objeto que irá atacar
    /// </param>
    /// 
    /// <returns>
    /// Retorna um vetor com o ângulo entre esse objeto e o jogador
    /// </returns>
    public static Vector3 getPlayerDirection (this IAttack attack, Transform shooter) {
      return Mission.spaceship != null ?
        (Mission.spaceship.transform.position - shooter.position).normalized
        :
        shooter.up
      ;
    }

  }

}
