using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskEffect
{
    public string taskName;
    public float modifier;
}
[System.Serializable]
public class TraitData
{
    public string traitName;
    public TaskEffect[] taskEffects;
}

[System.Serializable]
public class Trait : MonoBehaviour
{
    public TraitData traitData;
    public float GetEffectOnTask(string taskName){
        foreach(TaskEffect taskEffect in traitData.taskEffects){
            if(taskEffect.taskName == taskName)
            {
                return taskEffect.modifier;
            }
        }
        return 1;
    }
}
