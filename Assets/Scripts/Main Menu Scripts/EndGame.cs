using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject CreditsMenu;
    public GameObject WonGame;
    public GameObject LostGame;

    ProgressBarHandler progressBarHandler = new ProgressBarHandler();
    // Start is called before the first frame update
    void Start()
    {
        if(progressBarHandler.WonGameCheck == true){
            WonGame.SetActive(true);
            LostGame.SetActive(false);
        } else {
            WonGame.SetActive(false);
            LostGame.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButtonTapped(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    
}
