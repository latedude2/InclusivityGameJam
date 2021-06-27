using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cooking : PersistantTask
{
    static public float food = 30f;

    public float eatingRate = 0.5f;
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
        food -= eatingRate * Time.deltaTime;
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
        "Cooking speed: " + Mathf.Round(GetCooking()) + " potatoes/day\n" + 
        "Eating rate: " + eatingRate + " potatoes/day";
    }

    static public float HungerMultiplier(){
        if(food <= 0f)
        {
            food = 0f;
            return 0.2f;
        }
        else return 1f;
    }
}
