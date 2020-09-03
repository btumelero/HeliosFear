using UnityEngine;

namespace Assets.Source.Experimental.Movement {

  public class FadeTest : MonoBehaviour {

    public Renderer[] spaceshipParts { get; set; }
    public bool fadeIn;
    private enum Fade { IN, OUT }

    // Start is called before the first frame update
    void Start () {
      spaceshipParts = GetComponentsInChildren<Renderer>();
      fadeIn = true;
    }

    // Update is called once per frame
    void Update () {
      fade(fadeIn ? Fade.IN : Fade.OUT);
    }

    private void fade (Fade fade) {
      Color color;
      foreach (Renderer spaceshipPart in spaceshipParts) {
        if (spaceshipPart.material.HasProperty("_Color")) {
          color = spaceshipPart.material.color;
          color.a = Mathf.Clamp(
            color.a + (Time.deltaTime * (fade == Fade.IN ? -1 : 1)), 0, 1
          );
          spaceshipPart.material.color = color;
        } else {
          spaceshipPart.enabled = (fade == Fade.IN ? false : true);
        }
      }
    }

  }
}
