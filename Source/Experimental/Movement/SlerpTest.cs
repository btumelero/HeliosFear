using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Timers;
using UnityEngine;

namespace Assets.Source.Experimental.Movement{

  public class SlerpTest : MonoBehaviour {

    public GameObject orbit;
    public BoxCollider movementZone { get; set; }
    public Timer movementTimer { get; set; }

    public float slerpSpeed;

    private float fractionTraveled;

    private Vector3? slerpFinalPosition;

    private Vector3 slerpStartingPosition;

    public GameObject spaceship {
      get => gameObject;
    }

    // Start is called before the first frame update
    void Start () {
      movementTimer = gameObject.AddComponent<Timer>();
      movementTimer.baseTime = 1f;
      orbit = Instantiate(orbit);
      movementZone = orbit.GetComponentInChildren<BoxCollider>();
    }

    void FixedUpdate () {
      normalMovement();
    }

    public void normalMovement () {
      if (movementTimer.timeIsUp()) {
        if (slerpFinalPosition == null) {
          prepareForNextIteration();
        }
        if (spaceshipReachedDestination() == false) {
          slerpToDestination();
        } else {
          slerpFinalPosition = null;
          movementTimer.restart();
        }
      }

    }

    private void prepareForNextIteration () {
      slerpStartingPosition = spaceship.transform.position;
      slerpFinalPosition = movementZone.getRandomPointInside();
      fractionTraveled = 0;
      slerpSpeed = Mathf.Clamp(
        Time.fixedDeltaTime / Vector3.Distance(
          slerpStartingPosition.normalized, slerpFinalPosition.Value.normalized
        ),
        0.01f,
        0.1f
      );
    }

    private bool spaceshipReachedDestination () {
      return Vector3.Distance(spaceship.transform.position, slerpFinalPosition.Value) < 0.1f;
    }

    private void slerpToDestination () {
      fractionTraveled += slerpSpeed;
      spaceship.transform.position = Vector3.Slerp(
        slerpStartingPosition,
        slerpFinalPosition.Value,
        fractionTraveled
      );
    }
  }
}
