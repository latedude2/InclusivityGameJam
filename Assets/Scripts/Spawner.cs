using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{  
    public List<SpawnLocation> spawnLocations;
    public GameObject prefab;
   
    public void Spawn(){
        List<SpawnLocation> filtered = spawnLocations.FindAll(location => !location.used);
        if(filtered.Count > 0)
        {
            SpawnLocation selectedSpawn = filtered[Random.Range(0,filtered.Count)];
            GameObject task = Instantiate(prefab, selectedSpawn.location.position, Quaternion.identity);
            task.GetComponent<Task>().spawnLocation = selectedSpawn;
            selectedSpawn.used = true;
        }
        else {
            Debug.Log("No spawnpoints found");
        }
    }
}
