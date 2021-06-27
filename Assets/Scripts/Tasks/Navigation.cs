using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Navigation : PersistantTask
{
    private Text taskText;
    private GameObject taskBackground;

    void Start()
    {
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
        taskBackground = GameObject.Find("RoomInfoBackground");
    }
    public float GetNavigationBoost(){
        float navigationBoost = 1f;
        foreach(GameObject pirate in interactingPirates)
        {
            navigationBoost *= pirate.GetComponent<Pirate>().WorkOnTask("Navigation");
        }  
        return navigationBoost;
    }

    public void Select()
    {
        taskText.gameObject.SetActive(true);
        taskBackground.SetActive(true);
        taskText.text = "Navigation quality: " + Mathf.Round((GetNavigationBoost() - 1) * 100) + "%\n";
    }
}