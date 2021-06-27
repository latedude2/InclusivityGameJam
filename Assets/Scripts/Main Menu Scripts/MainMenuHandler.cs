using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        backButtonTapped();
    }

    // Update is called once per frame
    public void startGameButtonTapped(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void creditsButtonTapped(){
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void backButtonTapped(){
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
}
