using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToLoseScene : MonoBehaviour
{
    public GameObject CreditsMenu;
    public GameObject LostGame;

    // Start is called before the first frame update
    void Start()
    {
        LostGame.SetActive(true);
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
