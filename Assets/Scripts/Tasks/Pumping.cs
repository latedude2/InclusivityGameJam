using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pumping : PersistantTask
{
    private Text taskText;
    private GameObject taskBackground;
    public float waterLevel = 1f;
    public float basePumpingSpeed = 0.01f;
    public float baseFloodingSpeed = 0.002f;
    public float holeFloodingSpeed = 0.002f;
    public DisplacementBehaviour waterShader;
    public Spawner spawner;
    void Start()
    {
        taskText = GameObject.Find("GameManager").GetComponent<MouseInput>().taskPopup.GetComponent<Text>();
        taskBackground = GameObject.Find("RoomInfoBackground");
    }

    void Update()
    {
        waterLevel -= GetPumping() * Time.deltaTime;
        waterLevel += GetFlooding() * Time.deltaTime;
        waterLevel = Mathf.Clamp(waterLevel, 0, 1);
        waterShader._baseHeight = waterLevel;
    }

    private float GetFlooding()
    {
        float flooding = baseFloodingSpeed;
        List<SpawnLocation> holes = spawner.spawnLocations.FindAll(location => location.used);
        //Flooding from holes
        foreach(SpawnLocation hole in holes){
            flooding += holeFloodingSpeed;
        }
        return flooding;
    }

    private float GetPumping(){
        float pumping = 0f;
        foreach(GameObject pirate in interactingPirates )
        {
            pumping += basePumpingSpeed * pirate.GetComponent<Pirate>().WorkOnTask("Pumping");
        }   
        return pumping;
    }
    public void Select()
    {
        taskText.gameObject.SetActive(true);
        taskBackground.SetActive(true);
        taskText.text = "Water in Ship: " + + Mathf.Round(waterLevel * 100000) + "/100000L\n" + 
        "Flooding in: " + Mathf.Round(GetFlooding() * 100000) + "L/Min" + "\n" + 
        "Pumping out: " + + Mathf.Round(GetPumping() * 100000) + "L/Min";
        
    }
}
