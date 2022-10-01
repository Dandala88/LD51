using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public int cost;

    [HideInInspector]
    public bool handled;

    public bool handleable;


    protected Energy energyPrefab;

    protected List<int> modified = new List<int>();

    private void Start()
    {
        energyPrefab = GameManager.energy;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!handled)
        {
            int otherId = other.GetInstanceID();

            if (other.CompareTag("Energy") && !modified.Contains(otherId))
            {
                modified.Add(otherId);
                Triggered(other.transform, GetSideOfTrigger(other.transform.position));
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!handled)
        {
            int otherId = other.GetInstanceID();

            if (modified.Contains(otherId))
            {
                modified.Remove(otherId);
            }
        }
    }

    protected virtual void Triggered(Transform other, Vector3 triggerDirection)
    {
        Debug.LogWarning("Modifier Base class triggered called, failed to call override in child");
    }

    protected Energy Clone()
    {
        Energy clone = Instantiate(energyPrefab);
        modified.Add(clone.GetComponent<Collider>().GetInstanceID());
        return clone;
    }

    protected void ModDestroy(Transform other)
    {
        modified.Remove(other.GetComponent<Collider>().GetInstanceID());
        Destroy(other.gameObject);
    }

    protected Vector3 GetSideOfTrigger(Vector3 other)
    {
        float yVal = other.y - transform.position.y;
        float xVal = other.x - transform.position.x;
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
