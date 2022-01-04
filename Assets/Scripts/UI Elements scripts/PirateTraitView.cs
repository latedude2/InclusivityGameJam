using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateTraitView : MonoBehaviour
{
    public GameObject[] pirates;

    // Update is called once per frame
    void Update()
    {
        pirates = GameObject.FindGameObjectsWithTag("Pirate");
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
    }
}
