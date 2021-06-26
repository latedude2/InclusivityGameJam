using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : PersistantTask
{
    public float GetNavigationBoost(){
        float navigationBoost = 1;
        foreach(GameObject pirate in interactingPirates)
        {
            navigationBoost *= pirate.GetComponent<Pirate>().WorkOnTask("Navigation");
        }  
        return navigationBoost;
    }
}