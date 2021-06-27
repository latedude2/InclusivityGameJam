using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering: PersistantTask
{
    public Spawner holeSpawner;
    public Scouting scouting;
    public float steeringQuality = 0f;
    public float scoutingBoost = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(EncounterObstacle), 10.0f, 5f);
    }

    void EncounterObstacle(){
        scoutingBoost = scouting.GetScoutingBoost();
        //Pirate with best skill in range is chosen to steer
        foreach(GameObject pirate in interactingPirates )
        {
            if(steeringQuality < pirate.GetComponent<Pirate>().WorkOnTask("Steering")){
                steeringQuality = pirate.GetComponent<Pirate>().WorkOnTask("Steering");
            }
        }   
        //Roll for steering
        if(Random.Range(0f, 100f) + 50 * steeringQuality * scoutingBoost < 50)
        {
            Debug.Log("Spawning hole!");
            holeSpawner.Spawn();
        }
    }

    public float GetSteeringBoost(){
        //Pirate with best skill in range is chosen to steer
        foreach(GameObject pirate in interactingPirates )
        {
            if(steeringQuality < pirate.GetComponent<Pirate>().WorkOnTask("Steering")){
                steeringQuality = pirate.GetComponent<Pirate>().WorkOnTask("Steering");
            }
        }   
        return steeringQuality;
    }

}
