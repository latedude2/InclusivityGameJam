using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayTraits : MonoBehaviour
{
    public GameObject PirateTaskNames;
    public GameObject PirateModifiers;
    public GameObject StatsDisplayBackground;
    public GameObject Pirate;
    public GameObject pirateImageToShow;
    public Sprite pirateImage;
    private List<Text> pirateTaskNames;
    private List<Text> pirateModifiers;
    private List<Trait> traits;
    private List<string> traitStrings = new List<string>();
    private List<float> modifiers;

    // Start is called before the first frame update
    void Start() 
    {  
        traits = GetComponents<Trait>().ToList();
        pirateTaskNames = PirateTaskNames.GetComponentsInChildren<Text>().ToList();
        pirateModifiers = PirateModifiers.GetComponentsInChildren<Text>().ToList();

        //hideTraits();
        foreach(Trait trait in traits){
            traitStrings.Add(trait.traitName);
        }
    }

    void showPirateTraits(){
        int index = 0;
        foreach (Text pirateTaskName in pirateTaskNames)
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
