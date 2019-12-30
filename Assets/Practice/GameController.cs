using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    private const float MusicOffset = 1.15f;
    public ObjectPool objectpool;
    public GameObject prefab;
    private void Start()
    {
        AudioSource.PlayScheduled(AudioSettings.dspTime+MusicOffset);
        objectpool.CreatePool(prefab,50);
    }

    public GameObject GetNote()
    {
        return objectpool.GetObject();
    }
}
