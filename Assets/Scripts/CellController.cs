using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private GameObject cell;

    private CellController[] _links = new CellController[6];
    public CellGenome Genome;

    public int Level;
    public DNA Dna;
    public int direction;

    public bool isBranch;
    
    private void Start()
    {
        if (Genome.isRoot)
        {
            for (int i = 0; i < 6; i++)
            {
                CreateChild(i, 0, true);
            }
        }
        else if(Level < 15)
        {
            if (isBranch)
            {
                CreateChild(direction, Level + 1, true);
                CreateChild(GetNextDirection(direction), Level + 1, false);
            }
            else
            {
                CreateChild(direction , Level + 1, false);
            }
        }
    }

    private int GetNextDirection(int dir)
    {
        dir += 1;
        return dir > 5 ? dir - 6 : dir;
    }

    private Vector3 GetVectorToChild(int linkId)
    {
        Vector3 vector = new Vector3(1, 0, 0);
        switch (linkId)
        {
            case 1:
                vector = Quaternion.Euler(0, 0, 300) * vector;
                break;
            case 2:
                vector = Quaternion.Euler(0, 0, 240) * vector;
                break;
            case 3:
                vector = Quaternion.Euler(0, 0, 180) * vector;
                break;
            case 4:
                vector = Quaternion.Euler(0, 0, 120) * vector;
                break;
            case 5:
                vector = Quaternion.Euler(0, 0, 60) * vector;
                break;
            case 0:
            default:
                vector = vector;
                break;
        }

        return vector;
    }

    private void CreateChild(int direction, int level, bool isBranch)
    {
        var rootGO = Instantiate(cell, 
            transform.position + GetVectorToChild(direction), 
            Quaternion.identity);
        var cellController = rootGO.GetComponent<CellController>();
        cellController.direction = direction;
        cellController.Level = level;
        cellController.isBranch = isBranch;
        cellController.Dna = Dna;
        cellController.Genome = Instantiate(Dna.GetGenomeForLevel(level));
    }
    
}