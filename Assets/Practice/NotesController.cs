using System.Collections;
using System.Collections.Generic;
using UnityEngine;using System;


public class NotesController : MonoBehaviour
{
    public float speed = 7.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(transform.position.z) <0.1) Debug.Log(Time.timeSinceLevelLoad);
        transform.position += new Vector3(0,0,-Time.deltaTime*0.15f*speed*(float)McScore.Instance.time[0].bpm);
    }
}
