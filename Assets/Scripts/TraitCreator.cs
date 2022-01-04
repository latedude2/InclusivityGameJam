using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

[System.Serializable]

public class TraitCreator : MonoBehaviour
{

    private void Start() {
        List<Trait> traits = GetComponents<Trait>().ToList();
        List<TraitData> traitsData = new List<TraitData>();
        foreach(Trait trait in traits)
        {
            traitsData.Add(trait.traitData);
        }
        string json = JsonConvert.SerializeObject(traitsData);
        Debug.Log(json);
    }
}
