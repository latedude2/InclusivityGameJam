using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scouting : PersistantTask
{
    private Text taskText;
    private GameObject taskBackground;
    void Start()
    {
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
        taskBackground = GameObject.Find("RoomInfoBackground");
    }

    void Update(){
        ShowWarning();
    }

    private void ShowWarning(){
        GameObject warning = gameObject.transform.Find("Warning").gameObject;
        warning.SetActive(GetScoutingBoost() <= 1f);
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
        taskBackground.SetActive(true);
        taskText.gameObject.SetActive(true);
        taskText.text = "Scouting quality: " + Mathf.Round((GetScoutingBoost() - 1) * 100) + "%\n";
    }
}
