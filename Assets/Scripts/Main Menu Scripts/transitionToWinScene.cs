using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionToWinScene : MonoBehaviour
{
    public GameObject CreditsMenu;
    public GameObject WonGame;

    // Start is called before the first frame update
    void Start()
    {
        WonGame.SetActive(true);
        CreditsMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButtonTapped(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
