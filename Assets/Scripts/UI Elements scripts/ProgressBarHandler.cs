using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHandler : MonoBehaviour
{
    private bool wonGameCheck = false;
    public Slider slider;
    public Text progressInfo;
    private float progressValue = 0f;
    public float defaultProgressSpeed = 0.005f;
    public Navigation navigation;
    public Steering steering;
    public Scouting scouting;
    public Pumping pumping;
    public float ProgressValue {
        //Getting the progress value
        get{
            return progressValue;
        } 
        //Setting the sliders value
        set {
            progressValue = value;
            slider.value = progressValue;
        }
    }

    public bool WonGameCheck { get => wonGameCheck; set => wonGameCheck = value; }

    // Start is called before the first frame update
    void Start()
    {
        ProgressValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Add the progress to the progress bar.
        checkForUpdate(defaultProgressSpeed 
        * navigation.GetNavigationBoost() 
        * (0.5f + steering.GetSteeringBoost()) 
        * scouting.GetScoutingBoost() * (1 - pumping.waterLevel));
    }

    void checkForUpdate(float progress){
        if(progressValue >= 1f){
            WonGameCheck = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndGame");
        }
        else {
            ProgressValue += progress * Time.deltaTime;
            progressInfo.text = "Current progress: " + Mathf.Round(progressValue * 100) + "%\n" + 
            "Steering impact: " + Mathf.Round(steering.GetSteeringBoost()  * scouting.GetScoutingBoost() * 100) + "%\n" +
            "Navigation impact: " + Mathf.Round(navigation.GetNavigationBoost() * 100) + "%\n" + 
            "Ship flooding impact: " + Mathf.Round(pumping.waterLevel * 100 )+ "%\n";
        }
    }

    
}