using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    private bool isSelected = false;
    [SerializeField] private Transform target;
    // Start is called before the first frame update

    private List<Trait> traits; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected){
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public bool IsSelected(){
        return isSelected;
    }
    public void Select(bool select = true){
        isSelected = select;
    }

    public void WalkTo(Vector2 targetPosition){
        target.position = targetPosition;
    }
}
