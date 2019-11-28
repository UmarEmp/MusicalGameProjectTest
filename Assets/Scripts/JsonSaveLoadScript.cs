using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;
using Newtonsoft.Json;

public class JsonSaveLoadScript : MonoBehaviour
{
    public Transform GameManager;

    public string json;
    public int songCount;
    public int id;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CollectInfo();
            Loader();
        }
        
    }

    public void CollectInfo()
    {
        //int[] idSong = new int[songCount];
        //if(id<idSong.Length) idSong[id] = id;
        Vector3[] notePosition = new Vector3[GameManager.childCount]; 
        for(int i=0; i<notePosition.Length; i++)
        {
            notePosition[i] = GameManager.transform.GetChild(i).position;
        }
        List<NotePosition> list = new List<NotePosition>();

        foreach (Vector3 pos in notePosition)
        {
            list.Add(new NotePosition(pos));
        }
        List<MusicDataForJSon> musicDataList = new List<MusicDataForJSon>();
        musicDataList.Add(new MusicDataForJSon(0, list));
        musicDataList.Add(new MusicDataForJSon(1, list));
        musicDataList.Add(new MusicDataForJSon(2, list));
        ConvertToJson myObject = new ConvertToJson(musicDataList);
        //myObject.Load();

    }
    public void Loader()
    {
        string path = Application.persistentDataPath + "/data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //JsonData data = new JsonData();
            JsonData data = JsonMapper.ToObject(json);
            //List<NotePositin> list = JsonConvert.DeserializeObject(json);
            //Debug.Log(data.Count);
            //Debug.Log(data[0]["position"][0]);
            Debug.Log(data.Count + "Count off data");
            for (int i = 0; i < data.Count; i++)
            {
                Debug.Log(data[i]["id"][0]);
            }
        }
    }

}


[Serializable]
public class MusicDataForJSon
{
    public int id;
    [SerializeField]
    public List<NotePosition> position;

    public MusicDataForJSon(int id, List<NotePosition> list)
    {
        this.id = id;
        position = list;
    }

    public int getId()
    {
        return id;
    }

    public List<NotePosition> getPosition()
    {
        return position;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setPosition(List<NotePosition> position)
    {
        this.position = position;
    }

}

[Serializable]
public class ConvertToJson
{
    
    [SerializeField]
   // public int id = new int();
    public ConvertToJson(List<MusicDataForJSon> noteposition)
    {
        List<MusicDataForJSon> musicDataList = noteposition;

        string path = Application.persistentDataPath + "/data.json";
        if (!File.Exists(path))
        {
            StreamWriter sw = new StreamWriter(path);

            sw.Close();
        }

        //JsonData data = new JsonData()
        //{
        //    ["positions"] = JsonConvert.SerializeObject(noteposition),
        //};

        JsonData data = new JsonData();
        
            data.Add(JsonConvert.SerializeObject(musicDataList));

        File.WriteAllText(path, data.ToJson());
    }
    public ConvertToJson()
    {

    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //JsonData data = new JsonData();
            JsonData data = JsonMapper.ToObject(json);
            //List<NotePositin> list = JsonConvert.DeserializeObject(json);
           // Debug.Log(data.Count.ToString());
            for (int i = 0; i < data.Count; i++)
            {
                Debug.Log(data.GetType());
            }
           
        }
    }

}


[Serializable]
public class NotePosition
{
    [SerializeField]
    public Vector3 vecPosition;

    public NotePosition()
    {
    }

    public NotePosition(Vector3 vec)
    {
        vecPosition = vec;
    }
}