using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private Energy prefabBlock;
    [SerializeField]
    private Vector3 direction;

    private void Start()
    {
        StartCoroutine(GenBlockCoroutine());
    }

    private IEnumerator GenBlockCoroutine()
    {
        Energy clone = Instantiate(prefabBlock);
        clone.transform.position = transform.position;
        clone.NewDirection(direction);

        yield return new WaitForSeconds(10);
        StartCoroutine(GenBlockCoroutine());
    }
}
