using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskEffect
{
    [SerializeField] public string taskName;
    [SerializeField] public float modifier;
}
[System.Serializable]
public class Trait : MonoBehaviour
{
    [SerializeField] public string traitName;
    [SerializeField] public TaskEffect[] taskEffects;

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
