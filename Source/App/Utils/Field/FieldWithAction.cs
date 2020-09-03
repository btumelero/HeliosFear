using System;

namespace Assets.Source.Experimental {

  public class FieldWithAction<T> {

    #region Campos

    public T _Value;
    public Action onValueChange;

    #endregion

    #region Propriedades

    public T Value {
      get => _Value;
      set {
        _Value = value;
        onValueChange?.Invoke();
      }
    }

    #endregion

    #region Meus Métodos

    public override string ToString () {
      return Value.ToString();
    }

    #endregion

  }
}