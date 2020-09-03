using Assets.Source.App.Utils.Extensions;
using Assets.Source.App.Utils.Timers;
using UnityEngine;

namespace Assets.Source.Experimental.Movement{

  public class NewSlerpTest : MonoBehaviour {

    public float baseSpeed;
    public float actualSpeed;

    private Vector3? finalPosition;
    private Vector3 startingPosition;
    private Vector3 direction;

    public GameObject orbitSM;
    public GameObject orbitNM;

    public BoxCollider movementZone { get; set; }

    public Timer movementTimer { get; set; }
    public Timer movementDelayTimer { get; set; }

    public GameObject spaceship {
      get => gameObject;
    }

    void Start () {
      movementDelayTimer = gameObject.AddComponent<Timer>();
      movementTimer = gameObject.AddComponent<Timer>();
      movementDelayTimer.baseTime = 1f;
      orbitSM = Instantiate(orbitSM);
      movementZone = orbitSM.GetComponentInChildren<BoxCollider>();
      orbitNM = Instantiate(orbitNM);
      baseSpeed = 75;
      prepareForNextMovement();
    }


    void Update () {
      if (movementDelayTimer.timeIsUp()) {
        moveTowardsDestination();
      }
      if (movementTimer.timeIsUp()) {
        prepareForNextMovement();
        movementTimer.restart();
        movementDelayTimer.restart();
      }
    }

    private void prepareForNextMovement () {
      movementTimer.baseTime = Random.Range(2f, 3f);

      startingPosition = spaceship.transform.position;
      finalPosition = movementZone.getRandomPointInside();

      spaceship.transform.SetParent(null);
      orbitNM.transform.position = (startingPosition + finalPosition.Value) / 2;
      orbitNM.transform.localScale = Vector3.one;
      orbitNM.transform.localScale *= Vector3.Distance(startingPosition, finalPosition.Value);
      spaceship.transform.SetParent(orbitNM.transform);

      actualSpeed = Mathf.Clamp(baseSpeed * (1 + (10f / orbitNM.transform.localScale.x)), 0, 200);
      direction = (Mathf.Sign(Random.Range(-1, 1)) * Vector3.forward);
    }

    private void moveTowardsDestination () {
      orbitNM.transform.Rotate(direction * actualSpeed * Time.fixedDeltaTime, Space.Self);
      spaceship.transform.rotation = Quaternion.identity;
    }
  }
}
