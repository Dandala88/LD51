using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicator : MonoBehaviour
{
    public Energy prefabBlock;

    private List<int> modified = new List<int>();

    public void OnTriggerEnter(Collider other)
    {
        int otherId = other.GetInstanceID();

        if (other.CompareTag("Energy") && !modified.Contains(otherId))
        {
            modified.Add(otherId);

            Vector3 triggerDirection = GetSideOfTrigger(other.transform.position);

            other.transform.position = transform.position;
            other.GetComponent<Energy>().NewDirection(Quaternion.Euler(new Vector3(0f, 0f, -90f)) * triggerDirection);

            Energy clone = Instantiate(prefabBlock);
            modified.Add(clone.GetComponent<Collider>().GetInstanceID());
            clone.transform.position = transform.position;
            clone.NewDirection(Quaternion.Euler(new Vector3(0f, 0f, 90f)) * triggerDirection);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        int otherId = other.GetInstanceID();

        if (modified.Contains(otherId))
        {
            modified.Remove(otherId);
        }
    }

    private Vector3 GetSideOfTrigger(Vector3 position)
    {
        float yVal = position.y - transform.position.y;
        float xVal = position.x - transform.position.x;
        float uYVal = Mathf.Abs(yVal);
        float uXVal = Mathf.Abs(xVal);

        if (uYVal > uXVal)
        {
            if (yVal > 0)
                return Vector3.up;
            else
                return Vector3.down;
        }
        else
        {
            if (xVal > 0)
                return Vector3.right;
            else
                return Vector3.left;
        }
    }
}
