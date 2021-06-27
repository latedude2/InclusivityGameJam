using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBirb : MonoBehaviour
{
    public Transform farEnd;
    private Vector3 from;
    private Vector3 to;
    SpriteRenderer spriteRenderer;
    private float secondsForOneLength = 40f;

    void Start()
    {
        from = transform.position;
        to = farEnd.position;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        
        transform.position = Vector3.Lerp(from, to,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(Time.time / secondsForOneLength, 1f)
        ));
        if (transform.position == to)
        {
            spriteRenderer.flipX = true;
        }
        else if (transform.position == from)
        {
            spriteRenderer.flipX = false;
        }
    }
}