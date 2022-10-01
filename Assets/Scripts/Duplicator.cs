using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicator : Modifier
{
    protected override void Triggered(Transform other, Vector3 triggerDirection)
    {
        other.transform.position = transform.position;
        other.GetComponent<Energy>().NewDirection(Quaternion.Euler(new Vector3(0f, 0f, -90f)) * triggerDirection);

        Energy clone = Clone();
        clone.transform.position = transform.position;
        clone.NewDirection(Quaternion.Euler(new Vector3(0f, 0f, 90f)) * triggerDirection);
    }
}
