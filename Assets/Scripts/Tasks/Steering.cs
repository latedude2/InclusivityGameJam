using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steering: PersistantTask
{
    public Spawner holeSpawner;
    public Scouting scouting;
    private Text taskText;
    public float steeringQuality = 0f;
    public float scoutingBoost = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(EncounterObstacle), 10.0f, 5f);
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
    }

    void EncounterObstacle(){
        steeringQuality = 0f;
        scoutingBoost = scouting.GetScoutingBoost();
        //Pirate with best skill in range is chosen to steer
        foreach(GameObject pirate in interactingPirates )
        {
            if(steeringQuality < pirate.GetComponent<Pirate>().WorkOnTask("Steering")){
                steeringQuality = pirate.GetComponent<Pirate>().WorkOnTask("Steering");
            }
        }   
        //Roll for steering
        if(Random.Range(0f, 100f) + 50 * steeringQuality * scoutingBoost < 70)
        {
            Debug.Log("Spawning hole!");
            holeSpawner.Spawn();
        }
    }

    public float GetSteeringBoost(){
        steeringQuality = 0f;
        //Pirate with best skill in range is chosen to steer
        foreach(GameObject pirate in interactingPirates )
        {
            if(steeringQuality < pirate.GetComponent<Pirate>().WorkOnTask("Steering")){
                steeringQuality = pirate.GetComponent<Pirate>().WorkOnTask("Steering");
            }
        }   
        return steeringQuality;
    }

    public void Select()
    {
        taskText.gameObject.SetActive(true);
        taskText.text = "Steering quality: " + Mathf.Round(GetSteeringBoost() * 100) + "%\n";
    }

}
