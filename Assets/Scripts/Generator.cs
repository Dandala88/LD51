using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private float thisShouldBeTenSeconds = 10;
    [SerializeField]
    private Energy prefabBlock;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private AudioClip generateAudioClip;
    
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(GenBlockCoroutine());
    }

    private IEnumerator GenBlockCoroutine()
    {
        yield return new WaitForSecondsRealtime(thisShouldBeTenSeconds);
        Energy clone = Instantiate(prefabBlock);
        clone.transform.position = transform.position;
        clone.NewDirection(direction);
        animator.Play("Generate", 0);
        audioSource.PlayOneShot(generateAudioClip);
        StartCoroutine(GenBlockCoroutine());
    }

}
