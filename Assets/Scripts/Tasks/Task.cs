using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Task : MonoBehaviour
{
    public string taskName;
    private Text taskText; 
    public List<GameObject> interactingPirates;

    public SpawnLocation spawnLocation;
    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
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
            spawnLocation.used = false;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pirate")
        {
            Debug.Log("Collided with pirate!");
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

    public void Select()
    {
        taskText.gameObject.SetActive(true);
        taskText.text = "Work left: " + timeLeft;
    }
}
