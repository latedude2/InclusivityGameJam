using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayTraits : MonoBehaviour
{
    public GameObject PirateTaskNames;
    public GameObject PirateModefiers;
    private List<Text> pirateTaskNames;
    private List<Text> pirateModefiers;
    private Image pirateImage;
    public GameObject Pirate;
    private List<Trait> traits;
    private string[] taskNames = new string[3];
    private float[] modifiers = new float[3];

    // Start is called before the first frame update
    void Start() 
    {  
        traits = Pirate.GetComponents<Trait>().ToList();
        pirateTaskNames = PirateTaskNames.GetComponentsInChildren<Text>().ToList();
        pirateModefiers = PirateModefiers.GetComponentsInChildren<Text>().ToList();

        hideTraits();

    }

    // Update is called once per frame
    void Update()
    {   

    }

    public void showTraits(){
        foreach (Text pirateTaskName in pirateTaskNames)
        {
            pirateTaskName.enabled = true;
        }
        foreach (Text pirateModefier in pirateModefiers)
        {
            pirateModefier.enabled = true;
        }
        getPirateTraits();
        showPirateTaskNames();
        showPirateModefiers();
    }

    public void hideTraits(){
        foreach (Text pirateTaskName in pirateTaskNames)
        {
            pirateTaskName.enabled = false;
        }
        foreach (Text pirateModefier in pirateModefiers)
        {
            pirateModefier.enabled = false;
        }
    }

    void getPirateTraits(){
        int index = 0;
        foreach(Trait trait in traits){
            taskNames[index] = trait.taskEffects[0].taskName;
            modifiers[index] = trait.taskEffects[0].modifier;
            index ++;
        }
    }

    void showPirateTaskNames(){
        int index = 0;
        foreach (Text pirateTaskName in pirateTaskNames)
        {
            pirateTaskName.text = taskNames[index];
            index ++;
        }
    }

    void showPirateModefiers(){
        int index = 0;
        foreach (Text pirateModefier in pirateModefiers)
        {
            pirateModefier.text = string.Format("{0:N0}", modifiers[index]);
            index ++;
        }
    }
    
    void showImage(Image image){

    }

    //Image getPirateImage(){
        //Image image;
        //return image;
    //}
}
