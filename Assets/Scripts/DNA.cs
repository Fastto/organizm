using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DNA : ScriptableObject
{
    public CellGenome root;
    public List<CellGenome> genomes;
}
