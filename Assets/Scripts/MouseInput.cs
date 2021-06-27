using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public GameObject[] pirates;
    public GameObject taskPopup;
    public GameObject taskBackground;

    // Start is called before the first frame update
    void Start()
    {
        pirates = GameObject.FindGameObjectsWithTag("Pirate");
        taskPopup = GameObject.Find("RoomInfo");
        taskBackground = GameObject.Find("RoomInfoBackground");
    }

    void Update()
    {
        HideTaskPopup();
        RaycastHit2D[] hit;
        if (Input.GetMouseButtonDown(0))
        {       
            foreach(GameObject pirateGameObject in pirates)
            {
                pirateGameObject.GetComponent<Pirate>().Select(false);
            }     
            hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit.Length != 0) 
            {
                List<RaycastHit2D> hits = new List<RaycastHit2D>(hit);
                List<RaycastHit2D> pirates = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Pirate");
                if(pirates.Count != 0)
                    pirates[0].transform.gameObject.GetComponent<Pirate>().Select();
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
        hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        if (hit.Length != 0)  
        {
            List<RaycastHit2D> hits = new List<RaycastHit2D>(hit);
            List<RaycastHit2D> tasks = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Task");
            List<RaycastHit2D> steering = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Steering");
            List<RaycastHit2D> scouting = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Scouting");
            List<RaycastHit2D> pumping = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Pumping");
            List<RaycastHit2D> navigation = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Navigation");
            List<RaycastHit2D> cooking = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Cooking");
            if(tasks.Count != 0)
            {
                if(tasks[0].transform.gameObject.GetComponent<Task>() != null)
                    tasks[0].transform.gameObject.GetComponent<Task>().Select();
            }
            if (steering.Count != 0)
            {
                if(steering[0].transform.gameObject.GetComponent<Steering>() != null)
                    steering[0].transform.gameObject.GetComponent<Steering>().Select();
            }
            if (scouting.Count != 0)
            {
                if(scouting[0].transform.gameObject.GetComponent<Scouting>() != null)
                    scouting[0].transform.gameObject.GetComponent<Scouting>().Select();
            }
            if (pumping.Count != 0)
            {
                if(pumping[0].transform.gameObject.GetComponent<Pumping>() != null)
                    pumping[0].transform.gameObject.GetComponent<Pumping>().Select();
            }
            if (navigation.Count != 0)
            {
                if(navigation[0].transform.gameObject.GetComponent<Navigation>() != null)
                    navigation[0].transform.gameObject.GetComponent<Navigation>().Select();
            }
            if (cooking.Count != 0)
            {
                if(cooking[0].transform.gameObject.GetComponent<Cooking>() != null)
                    cooking[0].transform.gameObject.GetComponent<Cooking>().Select();
            }
        }  
    }

    void HideTaskPopup(){
        taskPopup.SetActive(false);
        taskBackground.SetActive(false);
    }
}
