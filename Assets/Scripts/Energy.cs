using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector3 direction;

    private Rigidbody rb;
    private static int count;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = direction * moveSpeed;
        gameObject.name += "_" + count;
        count++;
    }

    public void NewDirection(Vector3 newDirection)
    {
        direction = newDirection;
        rb.velocity = newDirection * moveSpeed;
    }
}
