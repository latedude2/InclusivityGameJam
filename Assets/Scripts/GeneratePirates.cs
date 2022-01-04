using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class GeneratePirates : MonoBehaviour
{
    List<int> availablePirateNumbers;
    public int traitCount = 3;
    public int pirateNumber = 4;
    private int maxPirateCount = 6;
    List<TraitData> possibleTraits = new List<TraitData>();
    List<GameObject> pirates  = new List<GameObject>();
    [SerializeField] GameObject PiratePrefab;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(nameof(ReadTraits));
    }

    void Generate()
    {
        availablePirateNumbers = new List<int>();
        for(int i = 1; i <= maxPirateCount; i++)
        {
            availablePirateNumbers.Add(i);
        }

        for(int i = 0; i < pirateNumber; i++)
        {
            GameObject pirate = CreatePirate();
            pirates.Add(pirate);
            pirate.transform.position = new Vector3(4f + i * 0.9f, -2f, 0f);
        }
    }

    GameObject CreatePirate()
    {
        GameObject pirate = Instantiate(PiratePrefab, transform);
        int pirateNumber = availablePirateNumbers[Random.Range(0, availablePirateNumbers.Count)];
        availablePirateNumbers.Remove(pirateNumber);

        string pirateAnimatorName = "Pirate" + pirateNumber;
        RuntimeAnimatorController pirateAnimator = Resources.Load<RuntimeAnimatorController>("Sprites/AnimationControllers/" + pirateAnimatorName);
        pirate.GetComponent<DisplayTraits>().pirateImage = Resources.Load<Sprite>("Sprites/PirateImages/" + pirateAnimatorName + "Image");

        List<TraitData> availableTraits = new List<TraitData>(possibleTraits);
        for(int i = 0; i < traitCount; i++)
        {
            pirate = AddTrait(pirate, availableTraits);
        }

        pirate.GetComponentInChildren<Animator>().runtimeAnimatorController = pirateAnimator;
        return pirate;
    }

    IEnumerator ReadTraits()
    {
        #if UNITY_EDITOR
            possibleTraits = JsonConvert.DeserializeObject<List<TraitData>>(File.ReadAllText(System.IO.Path.Combine(Application.streamingAssetsPath,"Traits.json")));
            yield return null;
        #elif UNITY_WEBGL
            string path = "StreamingAssets/Traits.json";
            UnityWebRequest uwr = UnityWebRequest.Get(path);
            yield return uwr.SendWebRequest();
            possibleTraits = JsonConvert.DeserializeObject<List<TraitData>>(uwr.downloadHandler.text);
            Debug.Log(uwr.downloadHandler.text);
        #else
            possibleTraits = JsonConvert.DeserializeObject<List<TraitData>>(File.ReadAllText(System.IO.Path.Combine(Application.streamingAssetsPath,"Traits.json")));
            yield return null;
        #endif

        Generate();
    }



    GameObject AddTrait(GameObject pirate, List<TraitData> availableTraits)
    {
        int traitNumber = Random.Range(0, availableTraits.Count);
        TraitData pirateTrait = availableTraits[traitNumber];
        availableTraits.RemoveAt(traitNumber);
        Trait newTrait = pirate.AddComponent<Trait>();
        newTrait.traitData = pirateTrait;
        return pirate;
    }

    public void RegeneratePirates()
    {
        foreach(GameObject pirate in pirates)
        {
            Destroy(pirate);
        }
        pirates = new List<GameObject>();

        Generate();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnMainMenuLevelLoad;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnMainMenuLevelLoad;
    }
    void OnMainMenuLevelLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }  
    }
}
