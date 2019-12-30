using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class NotesGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public struct note
    {
        public double notesendtime;
        public double notesmaketime;
    }

    private float MusicOffset = 0.920f;
    public List<GameObject> NoteObject = new List<GameObject>();
    public List<note> Note =new List<note>();
    public GameObject effect;
    private int _ignorenotes = 0;
    private int TouchNotes = 0;
    public Text Text;
    private float Nowtime=0;
    public GameController _gameController;
    private void Start()
    {
        for (int i = 0; i < McScore.Instance.note.Length-1; i++)
        {
            if (McScore.Instance.note[i].column.ToString().Equals(gameObject.name))
            {
                var note = new note();
                
                note.notesmaketime = (60 / (McScore.Instance.note[i].beat[2]*McScore.Instance.time[0].bpm))*(McScore.Instance.note[i].beat[2]*McScore.Instance.note[i].beat[0]+McScore.Instance.note[i].beat[1]);
                if (McScore.Instance.note[i].endbeat!=null)
                {
                    note.notesendtime = 60 / (McScore.Instance.note[i].endbeat[2]*McScore.Instance.time[0].bpm)*(McScore.Instance.note[i].endbeat[2]*McScore.Instance.note[i].endbeat[0]+McScore.Instance.note[i].endbeat[1]);
                }
                else
                {
                    note.notesendtime = 0;
                }
                Note.Add(note);
            }
            
        }


    }

    // Update is called once per frame
void Update()
    {
        Nowtime += Time.deltaTime;
        if (_ignorenotes > Note.Count - 1) return;
        if (Math.Abs(Nowtime - Note[_ignorenotes].notesmaketime) < 0.005)
        {
            if (Note[_ignorenotes].notesendtime == 0)
            {           
                var obj = _gameController.GetNote();
                NoteObject.Add(obj);
                switch (gameObject.name)
                {
                    case "0":obj.transform.position = new Vector3(-3.75f,0.0001f,10);
                        break;
                    case "1":obj.transform.position = new Vector3(-1.25f,0.0001f,10);
                        break;
                    case "2":obj.transform.position = new Vector3(1.25f,0.0001f,10);
                        break;
                    case "3":obj.transform.position = new Vector3(3.75f,0.0001f,10);
                        break;
                }
            }
            else
            {
                var obj= _gameController.GetNote();
                obj.transform.localScale = new Vector3(2.5f,0.0001f,(float)(Note[_ignorenotes].notesendtime-Note[_ignorenotes].notesmaketime )*0.15f*(float)McScore.Instance.time[0].bpm);
                NoteObject.Add(obj);
                switch (gameObject.name)
                {
                    case "0":obj.transform.position = new Vector3(-3.75f,0.0001f,10+((float)(Note[_ignorenotes].notesendtime-Note[_ignorenotes].notesmaketime )*0.15f*(float)McScore.Instance.time[0].bpm)/2.0f);
                        break;
                    case "1":obj.transform.position = new Vector3(-1.25f,0.0001f,10+((float)(Note[_ignorenotes].notesendtime-Note[_ignorenotes].notesmaketime )*0.15f*(float)McScore.Instance.time[0].bpm)/2.0f);
                        break;
                    case "2":obj.transform.position = new Vector3(1.25f,0.0001f,10+((float)(Note[_ignorenotes].notesendtime-Note[_ignorenotes].notesmaketime )*0.15f*(float)McScore.Instance.time[0].bpm)/2.0f);
                        break;
                    case "3":obj.transform.position = new Vector3(3.75f,0.0001f,10+((float)(Note[_ignorenotes].notesendtime-Note[_ignorenotes].notesmaketime )*0.15f*(float)McScore.Instance.time[0].bpm)/2.0f);
                        break;
                }
            }
            
            _ignorenotes +=1;
        }

        
        
        if (Input.GetKey(KeyCode.D) && gameObject.name == "0")
        {
            effect.SetActive(true);
        }else if (Input.GetKey(KeyCode.F) && gameObject.name == "1")
        {
            effect.SetActive(true);
        }else if (Input.GetKey(KeyCode.J) && gameObject.name == "2")
        {
            effect.SetActive(true);
        }else if (Input.GetKey(KeyCode.K) && gameObject.name == "3")
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.D) && gameObject.name == "0")
        {
            Judgement();
        }else if (Input.GetKeyDown(KeyCode.F) && gameObject.name == "1")
        {
            Judgement();
        }else if (Input.GetKeyDown(KeyCode.J) && gameObject.name == "2")
        {
            Judgement();
        }else if (Input.GetKeyDown(KeyCode.K) && gameObject.name == "3")
        {
            Judgement();
        }

        if ((Nowtime - Note[TouchNotes].notesmaketime - MusicOffset) > 0.060f)
        {
            if(NoteObject.Count==0) return;
            NoteObject[0].transform.localScale = new Vector3(2.5f,0.1f,0.5f);
            NoteObject[0].SetActive(false);
            NoteObject.RemoveAt(0);
            TouchNotes++;
        }


    }

    void Judgement()
        {            
            Debug.Log(Math.Abs(Nowtime - Note[TouchNotes].notesmaketime-MusicOffset));
            if(NoteObject.Count==0) return;
            if (Note[TouchNotes].notesendtime>0)
            {
                
            }
            if (Math.Abs(Nowtime - Note[TouchNotes].notesmaketime-MusicOffset) < 0.020f)
            {         

                NoteObject[0].SetActive(false);
                NoteObject.RemoveAt(0);
                Text.text = "GREAT";
                TouchNotes++;
            }
            else if (Math.Abs(Nowtime - Note[TouchNotes].notesmaketime - MusicOffset) < 0.030f)
            {      

                NoteObject[0].SetActive(false);
                NoteObject.RemoveAt(0);
                Text.text = "NICE";
                TouchNotes++;
            }else if (Math.Abs(Nowtime - Note[TouchNotes].notesmaketime - MusicOffset) < 0.050f)
            {    

                NoteObject[0].SetActive(false);
                NoteObject.RemoveAt(0);
                Text.text ="POOR";
                TouchNotes++;
            }else if (Math.Abs(Nowtime - Note[TouchNotes].notesmaketime - MusicOffset) < 0.060f)
            {       

                NoteObject[0].SetActive(false);
                NoteObject.RemoveAt(0);
                Text.text = "MISS";
                TouchNotes++;
            }

        }


}

