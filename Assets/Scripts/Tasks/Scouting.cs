using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scouting : PersistantTask
{
    private Text taskText;
    void Start()
    {
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
    }

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

    public void Select()
    {
        taskText.gameObject.SetActive(true);
        taskText.text = "Scouting quality: " + Mathf.Round((GetScoutingBoost() - 1) * 100) + "%\n";
    }
}
