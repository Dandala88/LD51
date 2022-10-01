using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Modifier
{
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        GameManager.AddEnergy(1);
        ModDestroy(other);
    }
}
