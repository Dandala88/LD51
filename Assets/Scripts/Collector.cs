using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Modifier
{
    [SerializeField]
    private AudioClip collectClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        GameManager.AddEnergy(1);
        ModDestroy(other);
        audioSource.PlayOneShot(collectClip);
    }
}
