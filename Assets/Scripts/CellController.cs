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
    public int parentLinkId;

    private void Start()
    {
        if (Genome.isRoot)
        {
            for (int i = 0; i < 6; i++)
            {
                var rootGO = Instantiate(cell, transform.position + GetVectorToChild(i), Quaternion.identity);
                var cellController = rootGO.GetComponent<CellController>();
                cellController.parentLinkId = i;
                cellController.Level = 0;
                cellController.Dna = Instantiate(Dna);
                cellController.Genome = Instantiate(Dna.root);
            }
        }
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
}