using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{

    public float moveSpeed;
    public State state;

    public enum State
    {
        Normal,
        Fast,
        Slow
    }
    [SerializeField]
    private Material normalMaterial;
    [SerializeField]
    private Material fastMaterial;
    [SerializeField]
    private Material slowMaterial;

    private Vector3 direction;

    private Rigidbody rb;
    private Renderer rend;
    private static int count;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
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

    public void NewSpeed(float speedModifier)
    {
        rb.velocity = direction * moveSpeed * speedModifier;
    }

    public void ChangeState(State sentState)
    {
        switch(sentState)
        {
            case State.Normal: 
                rend.material = normalMaterial;
                state = State.Normal;
                break;
            case State.Fast: 
                rend.material = fastMaterial;
                state = State.Fast;
                break;
            case State.Slow: 
                rend.material = slowMaterial;
                state = State.Slow;
                break;
        }
    }
}
