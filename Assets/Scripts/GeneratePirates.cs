using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePirates : MonoBehaviour
{
    [SerializeField] GameObject PiratePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject CreatePirate()
    {
        GameObject pirate = Instantiate(PiratePrefab, transform);
        
        return pirate;
    }
}
