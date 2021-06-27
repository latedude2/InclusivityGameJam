using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowElement : MonoBehaviour
{
    public void ShowGameObject(){
        gameObject.SetActive(true);
    }

    public void HideGameObject(){
        gameObject.SetActive(false);
    }
}
