using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSelector : MonoBehaviour
{
    [SerializeField]
    private Modifier prefab;

    public Modifier Generate()
    {
        Modifier clone = Instantiate(prefab);
        return clone;
    }
}
