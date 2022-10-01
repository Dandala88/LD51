using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSelector : MonoBehaviour
{
    [HideInInspector]
    public int cost;

    [SerializeField]
    private Modifier prefab;
    [SerializeField]
    private Material availableMaterial;
    [SerializeField]
    private Material unavailableMaterial;

    private void Awake()
    {
        cost = prefab.cost;
    }

    private void OnEnable()
    {
        GameManager.OnEnergyChange += MakeAvailable;
    }

    private void OnDisable()
    {
        GameManager.OnEnergyChange -= MakeAvailable;
    }

    public Modifier Generate()
    {
        Modifier clone = Instantiate(prefab);
        return clone;
    }

    public void MakeAvailable(int energy)
    {
        if(energy >= cost)
            GetComponent<Renderer>().material = availableMaterial;
        else
            GetComponent<Renderer>().material = unavailableMaterial;
    }
}
