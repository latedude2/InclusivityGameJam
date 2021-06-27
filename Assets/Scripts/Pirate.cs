using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pirate : MonoBehaviour
{
    private bool isSelected = false;

    private DisplayTraits displayTraits = new DisplayTraits();
    [SerializeField] private Transform target;
    // Start is called before the first frame update

    private List<Trait> traits; 
    void Start()
    {
        traits = GetComponents<Trait>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected){
            GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
            displayTraits.showTraits();
        }
        else {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
            displayTraits.hideTraits();
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
    
    public float WorkOnTask(string taskName){
        float workMultiplier = 1;
        foreach(Trait trait in traits){
            workMultiplier*= trait.GetEffectOnTask(taskName);
        }
        return workMultiplier;
    }
}
