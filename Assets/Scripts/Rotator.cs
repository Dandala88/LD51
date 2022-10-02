using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Modifier
{
    [SerializeField]
    private Vector3 rotation;

    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        other.transform.position = transform.position;
        other.GetComponent<Energy>().NewDirection(Quaternion.Euler(rotation) * triggerDirection);
    }
}
