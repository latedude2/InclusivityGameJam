using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public class GeneratePirates : MonoBehaviour
{
    List<int> availablePirateNumbers = new List<int>();
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
        ReadTraits();
        for(int i = 1; i <= maxPirateCount; i++)
        {
            availablePirateNumbers.Add(i);
        }

        for(int i = 0; i < pirateNumber; i++)
        {
            pirates.Add(CreatePirate());
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

    void ReadTraits()
    {
        possibleTraits = JsonConvert.DeserializeObject<List<TraitData>>(File.ReadAllText(Application.streamingAssetsPath + "/Traits.json"));
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

}
