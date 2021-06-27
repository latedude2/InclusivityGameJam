using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cooking : PersistantTask
{
    public float food = 100f;
    private Text taskText;
    private GameObject taskBackground;

    // Start is called before the first frame update
    void Start()
    {
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
        taskBackground = GameObject.Find("RoomInfoBackground");
    }

    void Update()
    {
        food += GetCooking() * Time.deltaTime;
        ShowWarning();
    }

    private void ShowWarning(){
        GameObject warning = gameObject.transform.Find("Warning").gameObject;
        warning.SetActive(GetCooking() <= 0f);
    }

    private float GetCooking(){
        float cooking = 0f;
        foreach(GameObject pirate in interactingPirates )
        {
            cooking += pirate.GetComponent<Pirate>().WorkOnTask("Cooking");
        }   
        return cooking;
    }

    public void Select()
    {
        taskText.gameObject.SetActive(true);
        taskBackground.SetActive(true);
        taskText.text = "Prepared food: " + + Mathf.Round(food) + " potatoes\n" + 
        "Cooking speed: " + Mathf.Round(GetCooking()) + " potatoes/Min";
    }
}
