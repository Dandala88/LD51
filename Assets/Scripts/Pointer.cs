using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : Modifier
{
    [SerializeField]
    private Vector3 direction;

    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        other.transform.position = transform.position;
        Energy energy = other.GetComponent<Energy>();
        energy.NewDirection(direction);
    }
}
