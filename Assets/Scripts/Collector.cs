using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Modifier
{
    [SerializeField]
    private AudioClip collectClip;

    private AudioSource audioSource;
    private Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        GameManager.AddEnergy(1);
        ModDestroy(other);
        audioSource.PlayOneShot(collectClip);
        animator.Play("Collect", 0);
    }
}
