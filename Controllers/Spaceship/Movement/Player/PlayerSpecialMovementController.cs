using Extensions;

using Interfaces.Movements;

using UnityEngine;

public class PlayerSpecialMovementController : PlayerMovementController, ISpecialMovement {

  #region Getters e Setters

  public Vector3 specialPosition { get; set; }

  #endregion

  #region Meus Métodos

  public void specialMovement () {
    transform.Rotate(
      0,
      0,
      -Input.GetAxis(Enums.Input.Horizontal.ToString()) * (_actualSpeed * 3) * Time.fixedDeltaTime
    );
  }

  public void switchToSpecialMovement () {
    gameObject.moveTowards(Vector3.zero, _actualSpeed);
    if (gameObject.isAt(Vector3.zero)) {
      fixPlayerScreenView();
      move = specialMovement;
    }
  }

  public void switchToNormalMovement () {
    if (gameObject.rotationIsZero() == false) {
      gameObject.rotateTowards(Quaternion.Euler(0, 0, 0), _actualSpeed * 3);
      gameObject.moveTowards(_startingPosition, _actualSpeed);
    } else {
      fixPlayerScreenView();
      move = normalMovement;
    }
  }

  private void fixPlayerScreenView () {
    GameObject blackSides = GameObject.FindWithTag(Enums.Tags.BlackSides.ToString());
    blackSides.transform.localScale = new Vector3(
      blackSides.transform.localScale.x == 1 ? 1.23f : 1,
      1,
      1
    );
  }

  #endregion

}
