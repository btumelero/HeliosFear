using System;

using Assets.Source.App.Utils.Enums;

namespace Assets.Source.App.Controllers.Spaceship.Energy {

  /// <summary>
  /// Classe container para os valores que serão usados para multiplicar valores bases 
  /// para obter o valor real (i.e. base * multiplicador = real).
  /// </summary>
  public class Multipliers {

    /// <summary>
    /// Os eventos que serão disparados ao mudar o valor de um multiplicador
    /// </summary>
    private event Action<Sliders?> onValueChange;

    /// <summary>
    /// Os multiplicadores
    /// </summary>
    private readonly float[] multipliers;

    /// <summary>
    /// Acessa o array de multiplicadores usando o enum Energy.
    /// Retorna o valor com ou sem modificações dependendo do valor de raw.
    /// Dispara os eventos ao modificar um valor.
    /// </summary>
    /// 
    /// <param name="slider">
    /// O modificador será acessado
    /// </param>
    /// 
    /// <param name="raw">
    /// Se o retorno deve ser retornado sem modificações ou já divido por cinquenta (valor real)
    /// </param>
    /// 
    /// <returns>
    /// Um multiplicador modificado ou não, dependendo do valor de raw 
    /// </returns>
    public float this[Sliders slider, bool raw] {
      get => multipliers[(int) slider] / (raw ? 1 : 50);
      set {
        multipliers[(int) slider] = value;
        onValueChange?.Invoke(slider);
      }
    }

    public Multipliers (Action<Sliders?> onValueChange) {
      this.onValueChange = onValueChange;
      multipliers = new float[3];
    }

    public Multipliers (
      Action<Sliders?> onValueChange,
      float shield, float speed, float weapon
    ) : this(onValueChange) {
      multipliers[0] = shield;
      multipliers[1] = speed;
      multipliers[2] = weapon;
    }

  }
}