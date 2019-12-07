using Interfaces;
using UnityEngine;

namespace Extensions {

  public static class ISpecialAttackExtension {

    /**
     * Calcula o ângulo em que o tiro deve ser disparado e 
     * transforma o resultado em um vetor com valores de 0~1 pra unity poder usar o vetor
     */
    public static Vector3 getPlayerDirection (this ISpecialAttack attack, Transform shooter) {
      return Mission.spaceship != null ?
        (Mission.spaceship.transform.position - shooter.position).normalized
        :
        shooter.up
      ;
    }

  }

}
