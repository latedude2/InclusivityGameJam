using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumping : PersistantTask
{
    public float waterLevel = 1f;
    public float basePumpingSpeed = 0.01f;
    public float baseFloodingSpeed = 0.002f;
    public float holeFloodingSpeed = 0.002f;
    public DisplacementBehaviour waterShader;
    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject pirate in interactingPirates )
        {
            waterLevel -= basePumpingSpeed * pirate.GetComponent<Pirate>().WorkOnTask("Pumping") * Time.deltaTime;
        }   
        List<SpawnLocation> holes = spawner.spawnLocations.FindAll(location => location.used);
        //Flooding from holes
        foreach(SpawnLocation hole in holes){
            waterLevel += holeFloodingSpeed * Time.deltaTime;
        }
        //Base/default flooding
        waterLevel += baseFloodingSpeed * Time.deltaTime;
        waterLevel = Mathf.Clamp(waterLevel, 0, 1);
        waterShader._baseHeight = waterLevel;
    }
}
