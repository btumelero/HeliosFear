using System;

using Assets.Source.App.Utils.Interfaces.Builders;

using UnityEngine;

namespace Assets.Source.App.Builders {

  public class Builder {

    private IBuilder builder;
    private Action onBuild;

    public Builder build (GameObject gameObject) {
      builder.objectToBuild = gameObject;
      onBuild();
      return this;
    }

    public Builder set (IBuilder builder) {
      this.builder = builder;
      onBuild = builder.getActions();
      return this;
    }
  }

}