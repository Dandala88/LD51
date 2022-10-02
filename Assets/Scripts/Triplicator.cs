using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triplicator : Modifier
{
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        other.transform.position = transform.position;

        Energy clone = Clone();
        clone.transform.position = transform.position;
        clone.NewDirection(Quaternion.Euler(new Vector3(0f, 0f, 90f)) * triggerDirection);

        Energy clone2 = Clone();
        clone2.transform.position = transform.position;
        clone2.NewDirection(Quaternion.Euler(new Vector3(0f, 0f, -90f)) * triggerDirection);
    }
}
