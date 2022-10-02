using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridifier : MonoBehaviour
{
    [SerializeField]
    private GameObject center;
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;

    private List<GameObject> centers = new List<GameObject>();

    private void Start()
    {
        for(int i = -width/2 ; i < width/2; i++)
        {
            for(int j = -height/2; j < height/2; j++)
            {
                GameObject newCenter = Instantiate(center);
                newCenter.transform.parent = gameObject.transform;
                center.transform.position = new Vector3(i, j, 0f);
                centers.Add(newCenter);
                newCenter.SetActive(false);
            }
        }
    }

    public void Activate(bool activate)
    {
        foreach (GameObject c in centers)
            c.SetActive(activate);
    }
}
