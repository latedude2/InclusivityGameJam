using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using SAP2D;

public class DisplayTraits : MonoBehaviour
{
    public GameObject PirateTraitNames;
    public GameObject PirateModifiers;
    public GameObject StatsDisplayBackground;
    public GameObject Pirate;
    public GameObject pirateImageToShow;
    public Sprite pirateImage;
    private List<Text> pirateTraitNames;
    private List<Text> pirateModifiers;
    private List<Trait> traits;
    private List<string> traitStrings = new List<string>();
    private List<float> modifiers;
    
    void Start() {
        StatsDisplayBackground = GameObject.Find("StatsDisplayBackground");
        pirateImageToShow = GameObject.Find("pirateImage");   
        getUI();
        
    }

    void getUI()
    {
        PirateTraitNames = GameObject.Find("PirateTraitNames");
        PirateModifiers = GameObject.Find("PirateModifiers");
        traits = GetComponents<Trait>().ToList();
        pirateTraitNames = PirateTraitNames.GetComponentsInChildren<Text>().ToList();
        pirateModifiers = PirateModifiers.GetComponentsInChildren<Text>().ToList();

        //hideTraits();
        foreach(Trait trait in traits){
            traitStrings.Add(trait.traitData.traitName);
        }
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

    void OnMainLevelLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "Main")
        {
            return;
        }
        
        StatsDisplayBackground = GameObject.Find("StatsDisplayBackground");
        pirateImageToShow = GameObject.Find("pirateImage");
        GetComponent<SAP2DAgent>().enabled = true;

        getUI();
    }

    void showPirateTraits(){
        int index = 0;
        foreach (Text pirateTaskName in pirateTraitNames)
        {
            if(traitStrings.Count > index)
                pirateTaskName.text = traitStrings[index];
            else{
                pirateTaskName.text = "";
            }
            index++;
        }
    }

    public void updateTraits(){
        showPirateTraits();
        showImage(pirateImage);
    } 
    void showImage(Sprite image){
        pirateImageToShow.GetComponent<Image>().sprite = image;
    }

}
