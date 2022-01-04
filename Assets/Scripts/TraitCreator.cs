using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class TraitCreator : MonoBehaviour
{
    [SerializeField] List<Trait> traits = new List<Trait>();

    private void Start() {
        traits = GetComponents<Trait>().ToList();
        
    }
}
