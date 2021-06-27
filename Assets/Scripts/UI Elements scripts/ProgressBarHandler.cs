using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHandler : MonoBehaviour
{
    private bool wonGameCheck = false;
    public Slider slider;
    private float progressValue = 1f;
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
        * steering.GetSteeringBoost() 
        * scouting.GetScoutingBoost() * (1 - pumping.waterLevel));
    }

    void checkForUpdate(float progress){
        if(progress == 1f){
            WonGameCheck = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndGame");
        }
        else {
            ProgressValue += progress * Time.deltaTime;
        }
    }

    
}