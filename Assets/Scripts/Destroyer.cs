using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : Modifier
{
    [SerializeField]
    private State state;
    [SerializeField]
    private int despawnSeconds;
    [SerializeField]
    private bool destroyDestroyer;

    public enum State
    {
        Normal,
        Fast,
        Slow
    }

    private Renderer renderer;
    private Collider collider;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        if (other.GetComponent<Energy>().state == Energy.State.Fast && state == State.Fast)
            StartCoroutine(UnSpawnCoroutine(other.gameObject));
        else if (other.GetComponent<Energy>().state == Energy.State.Slow && state == State.Slow)
            StartCoroutine(UnSpawnCoroutine(other.gameObject));
        else
            ModDestroy(other);
    }

    private IEnumerator UnSpawnCoroutine(GameObject destroyer)
    {
        if (destroyDestroyer)
            Destroy(destroyer);
        renderer.enabled = false;
        collider.enabled = false;
        yield return new WaitForSecondsRealtime(despawnSeconds);
        renderer.enabled = true;
        collider.enabled = true;
    }
}
