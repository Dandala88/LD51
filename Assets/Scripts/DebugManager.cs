using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [ContextMenu("Add 10 Energy")]
    public void AddTenEnergy()
    {
        GameManager.AddEnergy(10);
        Debug.Log(GameManager.totalEnergy);
    }

    [ContextMenu("Add 1 Energy")]
    public void AddOneEnergy()
    {
        GameManager.AddEnergy(1);
        Debug.Log(GameManager.totalEnergy);
    }

    [ContextMenu("Log Total Energy")]
    public void LogTotalEnergy()
    {
        Debug.Log(GameManager.totalEnergy);
    }
}
