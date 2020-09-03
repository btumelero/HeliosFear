using System.Collections;

using Assets.Source.App.Utils.Extensions;

using UnityEngine;

namespace Assets.Source.App.Utils.Coroutines {

  public class CoroutineController : MonoBehaviour {

    public IEnumerator coroutine { get; private set; }

    public void play (IEnumerator newCoroutine) {
      stop();
      coroutine = newCoroutine;
      if (coroutine != null) {
        StartCoroutine(coroutine);
      }
    }

    public void stop () {
      if (coroutine != null) {
        StopCoroutine(coroutine);
        coroutine = null;
      }
    }

    public bool isPlaying (IEnumerator enumerator) {
      return coroutine.equals(enumerator) == true;
    }

  }
}