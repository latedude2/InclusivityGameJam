using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using SAP2D;

public class Pirate : MonoBehaviour
{
    private bool isSelected = false;

    private DisplayTraits displayTraits;
    [SerializeField] private Transform target;
    // Start is called before the first frame update

    private List<Trait> traits; 
    void Start()
    {
        traits = GetComponents<Trait>().ToList();
        displayTraits = GetComponent<DisplayTraits>();
    }

    void OnEnable()
    {
    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnMainLevelLoad;
    }

    void OnDisable()
    {
    //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnMainLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        //displayTraits.hideUIElements();
        if(isSelected){
            GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
            displayTraits.updateTraits();
            //displayTraits.showUIElements();
        }
        else {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
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

    void OnMainLevelLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "Main")
        {
            return;
        }
        target = GameObject.Find("Pirate" + (transform.GetSiblingIndex() + 1) + "Target").transform;
        GetComponent<SAP2DAgent>().Target = target;
    }
}
