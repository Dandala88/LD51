using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : Modifier
{
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        ModDestroy(other);
    }
}
