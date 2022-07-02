using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    [SerializeField] private DNA dna;
    [SerializeField] private GameObject cell;
    [SerializeField] private EnvironmentController environment;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Birth(Vector3.zero));
    }
    

    IEnumerator Birth(Vector3 rootPosition)
    {
        yield return null;

        var rootGO = Instantiate(cell, rootPosition, Quaternion.identity);
        var cellController = rootGO.GetComponent<CellController>();
        cellController.Level = 0;
        cellController.Dna = Instantiate(dna);
        cellController.Genome = Instantiate(dna.root);
    }
}
