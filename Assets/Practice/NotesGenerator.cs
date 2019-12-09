using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public struct note
    {
        public int column;
        public double notesendtime;
        public double notesmaketime;
    }

    public GameObject prefab;
    public ObjectPool objectpool;
    public note[] Note;
    private int ignorenotes=0;
    public float starttime=0;
    public float Nowtime=0;
    private GameObject obj;
    private void Start()
    {
        objectpool.CreatePool(prefab,50);
        Note = new note[McScore.Instance.note.Length-1];
        for (int i = 0; i < Note.Length-1; i++)
        {
            Note[i].column = McScore.Instance.note[i].column;
            Note[i].notesmaketime = (60 / (McScore.Instance.note[i].beat[2]*McScore.Instance.time[0].bpm))*(McScore.Instance.note[i].beat[2]*McScore.Instance.note[i].beat[0]+McScore.Instance.note[i].beat[1]);
            if (McScore.Instance.note[i].endbeat!=null)
            {
                Note[i].notesendtime = 60 / (McScore.Instance.note[i].endbeat[2]*McScore.Instance.time[0].bpm)*(McScore.Instance.note[i].endbeat[2]*McScore.Instance.note[i].endbeat[0]+McScore.Instance.note[i].endbeat[1]);
            }
            else
            {
                Note[i].notesendtime = 0;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {   
        Nowtime += Time.deltaTime;


        for (int i = ignorenotes; i < ignorenotes+4; i++)
        {
            if (Math.Abs(Nowtime - Note[i].notesmaketime) < 0.005)
            {
                ignorenotes = i+1;
                obj = objectpool.GetObject();
                switch (Note[i].column)
                {
                    case 0:obj.transform.position = new Vector3(-3.75f,0.001f,10);
                        break;
                    case 1:obj.transform.position = new Vector3(-1.25f,0.001f,10);
                        break;
                    case 2:obj.transform.position = new Vector3(1.25f,0.001f,10);
                        break;
                    case 3:obj.transform.position = new Vector3(3.75f,0.001f,10);
                        break;
                }
            } 
        }
       
    }
}
