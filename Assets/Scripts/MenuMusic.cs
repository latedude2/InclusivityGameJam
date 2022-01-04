using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnMainLevelLoad;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnMainLevelLoad;
    }
    void OnMainLevelLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Main")
        {
            Destroy(gameObject);
        }  
    }

    private static MenuMusic _instance;

    public static MenuMusic Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}
