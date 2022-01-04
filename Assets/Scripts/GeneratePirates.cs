using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePirates : MonoBehaviour
{
    List<int> availablePirateNumbers = new List<int>();
    List<GameObject> pirates  = new List<GameObject>();
    [SerializeField] GameObject PiratePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; ++i)
        {
            availablePirateNumbers.Add(i);
        }

        for(int i = 0; i < 4; i++)
        {
            pirates.Add(CreatePirate());
        }
    }

    GameObject CreatePirate()
    {
        GameObject pirate = Instantiate(PiratePrefab, transform);
        int pirateNumber = availablePirateNumbers[Random.Range(1, availablePirateNumbers.Count)];
        availablePirateNumbers.Remove(pirateNumber);

        string pirateAnimatorName = "Pirate" + pirateNumber;
        RuntimeAnimatorController pirateAnimator = Resources.Load<RuntimeAnimatorController>("Sprites/AnimationControllers/" + pirateAnimatorName);

        pirate.GetComponentInChildren<Animator>().runtimeAnimatorController = pirateAnimator;
        return pirate;
    }
}
