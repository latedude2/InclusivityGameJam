using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskEffect
{
    public string taskName;
    public float modifier;
}

public class Trait : MonoBehaviour
{
    public string traitName;
    public TaskEffect[] taskEffects;

    public float GetEffectOnTask(string taskName){
        foreach(TaskEffect taskEffect in taskEffects){
            if(taskEffect.taskName == taskName)
            {
                return taskEffect.modifier;
            }
        }
        return 1;
    }
}
