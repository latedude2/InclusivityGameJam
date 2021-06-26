using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scouting : PersistantTask
{
    public float GetScoutingBoost(){
        float scoutingBoost = 1;
        foreach(GameObject pirate in interactingPirates)
        {
            if(scoutingBoost < pirate.GetComponent<Pirate>().WorkOnTask("Scouting")){
                scoutingBoost = pirate.GetComponent<Pirate>().WorkOnTask("Scouting");
            }
        }  
        return scoutingBoost;
    }
}
