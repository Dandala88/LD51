using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinger : Modifier
{
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        other.position = transform.position + triggerDirection;
        other.GetComponent<Energy>().NewDirection(Vector3.zero);
        other.SetParent(transform);
    }

    public void Release(Energy energy, Vector3 triggerDirection)
    {
        energy.transform.parent = null;
        energy.NewDirection(-triggerDirection);
    }
}
