using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedUnityEvent : MonoBehaviour
{
    public float delay = 3f;
    public UnityEvent delayedEvent;

    private void OnEnable()
    {
        StartCoroutine(FireAfterDelay());
    }

    private IEnumerator FireAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        delayedEvent?.Invoke();
    }
}
