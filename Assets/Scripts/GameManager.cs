using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Energy energyPrefab;

    public static Energy energy;

    private void Awake()
    {
        energy = energyPrefab;
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 6);
    }
}
