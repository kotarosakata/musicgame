using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class JsonReader : MonoBehaviour
{
    private string json;

    public string FilePath;


    // Start is called before the first frame update
    void Awake()
    {
        json = File.ReadAllText(FilePath);
        JsonUtility.FromJsonOverwrite(json,McScore.Instance);

    }


}

[Serializable]
public class McScore
{
    public static readonly McScore Instance = new McScore();
    public MusicTimeData[] time;
    public MusicMetaData meta;
    public MusicNoteData[] note;
    public MusicExtraData extra;
}
[Serializable]
public class MusicMetaData
{
    public string creator;
    public string background;
    public string version;
    public int id;
    public int mode;
    public int time;
    public MusicSongData song;
    public MusicMode_ExtData mode_ext;

}
[Serializable]
public class MusicMode_ExtData
{
    public int column;
}
[Serializable]
public class MusicSongData
{
    public string title;
    public string artist;
    public int id;
}
[Serializable]
public class MusicTimeData
{
    
    public int[] beat;
    public double bpm;
} 

[Serializable]
public class MusicNoteData
{
    public int[] beat;
    public int[] endbeat;
    public int column;
    public string sound;
    public int vol;
    public int offset;
    public int type;
} 
[Serializable]
public class MusicExtraData
{
    public MusicTestData test;
}
[Serializable]

public class MusicTestData
{
    public int divide;
    public int speed;
    public int save;
    public int a;
    //public int lock;
    public int edit_mode;

}