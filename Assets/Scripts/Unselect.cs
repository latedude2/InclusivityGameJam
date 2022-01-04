using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unselect : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {     
            RaycastHit2D[] hit;  
            hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit.Length != 0) 
            {
                List<RaycastHit2D> hits = new List<RaycastHit2D>(hit);
                List<RaycastHit2D> pirates = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Pirate");
                if(pirates.Count == 0)
                {
                    StopShowingTraits();
                }
            }
            else {
                StopShowingTraits();
            }
        }
    }

    void StopShowingTraits()
    {
        GameObject.Find("pirateImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Placeholder");
        GameObject.Find("cookingTaskNameText").GetComponent<Text>().text = " ";
        GameObject.Find("scoutingTaskNameText").GetComponent<Text>().text = " ";
        GameObject.Find("steeringTaskNameText").GetComponent<Text>().text = " ";
    }
}
