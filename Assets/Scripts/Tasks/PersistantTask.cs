using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersistantTask : MonoBehaviour
{
    public string taskName;
    public List<GameObject> interactingPirates;

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
}
