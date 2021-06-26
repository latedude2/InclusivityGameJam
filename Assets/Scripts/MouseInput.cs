using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public GameObject[] pirates;
    // Start is called before the first frame update
    void Start()
    {
        pirates = GameObject.FindGameObjectsWithTag("Pirate");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {       
            foreach(GameObject pirateGameObject in pirates)
            {
                pirateGameObject.GetComponent<Pirate>().Select(false);
            }     
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit) 
            {
                Debug.Log("Hit " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "Pirate")
                {
                    hit.transform.gameObject.GetComponent<Pirate>().Select();
                    Debug.Log ("Selected Pirate!");
                } else {
                    Debug.Log ("Selected nothing :(");
                }
            } else {
                Debug.Log("No hit");
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
    }
}
