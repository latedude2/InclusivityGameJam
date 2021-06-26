using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public string taskName;
    public List<GameObject> interactingPirates;
    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject pirate in interactingPirates )
        {
            timeLeft -= pirate.GetComponent<Pirate>().WorkOnTask(taskName) * Time.deltaTime;
        }   
        if(timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pirate")
        {
            if(!interactingPirates.Contains(col.gameObject))
            interactingPirates.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pirate")
        {
            interactingPirates.Remove(col.gameObject);
        }
    }
}
