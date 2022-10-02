using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Modifier
{
    [SerializeField]
    private float speedFactor;
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        Energy energy = other.GetComponent<Energy>();
        energy.NewSpeed(speedFactor);
        energy.ChangeState(Energy.State.Slow);
    }
}
