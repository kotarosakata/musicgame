using System.Collections;
using System.Collections.Generic;
using UnityEngine;using System;


public class NotesController : MonoBehaviour
{
    private float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0,0,-Time.deltaTime*0.03f*speed*(float)McScore.Instance.time[0].bpm);
    }
}
