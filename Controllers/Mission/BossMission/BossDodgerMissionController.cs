using UnityEngine;

public class BossDodgerMissionController : BossMissionController {

  #region Variáveis

  public Material normal, special;
  public Renderer spaceship { get; set; }

  #endregion

  #region Meus Métodos

  public void switchMaterial () {
    spaceship.material = spaceship.material == special ? normal : special;
  }

  public void fade (bool fadeIn) {
    Color color = spaceship.material.color;
    color.a = Mathf.Clamp(color.a + (Time.deltaTime * (fadeIn ? 1 : -1)), 0, 1);
    spaceship.material.color = color;
  }

  public override void bossMission () {

  }

  public override void postBossMission () {

  }

  #endregion

}
