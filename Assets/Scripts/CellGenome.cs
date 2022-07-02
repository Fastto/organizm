using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CellGenome : ScriptableObject
{
    public bool isRoot;
    
    [Range(0, 10)]
    public int getEnergyRate;
    
    [Range(0, 10)]
    public int storeEnergyRate;
}
