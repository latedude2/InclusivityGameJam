using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public GameObject[] pirates;
    public GameObject taskPopup;

    // Start is called before the first frame update
    void Start()
    {
        pirates = GameObject.FindGameObjectsWithTag("Pirate");
        taskPopup = GameObject.Find("RoomInfo");
    }

    void Update()
    {
        HideTaskPopup();
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0))
        {       
            foreach(GameObject pirateGameObject in pirates)
            {
                pirateGameObject.GetComponent<Pirate>().Select(false);
            }     
            hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit) 
            {
                if (hit.transform.gameObject.tag == "Pirate")
                {
                    hit.transform.gameObject.GetComponent<Pirate>().Select();
                }
            }
        } 
        if(Input.GetMouseButtonDown(1))
        {
            foreach(GameObject pirateGameObject in pirates)
            {
                if(pirateGameObject.GetComponent<Pirate>().IsSelected())
                {
                    pirateGameObject.GetComponent<Pirate>().WalkTo(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
                }
            }     
        }
        hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        if (hit) 
        {
            if (hit.transform.gameObject.tag == "Task")
            {
                if(hit.transform.gameObject.GetComponent<Task>() != null)
                    hit.transform.gameObject.GetComponent<Task>().Select();
            }
            if (hit.transform.gameObject.tag == "Steering")
            {
                if(hit.transform.gameObject.GetComponent<Steering>() != null)
                    hit.transform.gameObject.GetComponent<Steering>().Select();
            }
            if (hit.transform.gameObject.tag == "Scouting")
            {
                if(hit.transform.gameObject.GetComponent<Scouting>() != null)
                    hit.transform.gameObject.GetComponent<Scouting>().Select();
            }
            if (hit.transform.gameObject.tag == "Pumping")
            {
                if(hit.transform.gameObject.GetComponent<Pumping>() != null)
                    hit.transform.gameObject.GetComponent<Pumping>().Select();
            }
            if (hit.transform.gameObject.tag == "Navigation")
            {
                if(hit.transform.gameObject.GetComponent<Navigation>() != null)
                    hit.transform.gameObject.GetComponent<Navigation>().Select();
            }
            if (hit.transform.gameObject.tag == "Cooking")
            {
                if(hit.transform.gameObject.GetComponent<Cooking>() != null)
                    hit.transform.gameObject.GetComponent<Cooking>().Select();
            }
        }  
    }

    void HideTaskPopup(){
        taskPopup.SetActive(false);
    }
}
