using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using Newtonsoft.Json;
using System;

public class WriteJson : MonoBehaviour
{
    public Transform GameManager;
    public int id;
    public List<Vector3> position;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            WriteToJson();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Loader();
        }
    }

    public void WriteToJson()
    {
        for (int i = 0; i < GameManager.childCount; i++)
        {
            position.Add(GameManager.transform.GetChild(i).position);
        }
        
        List<MusicDataForJSon> music = new List<MusicDataForJSon>(2);
        for(int i=0; i < music.Count; i++)
        {
            music.Add(new MusicDataForJSon(i, position));
        }
        JsonData musicJson;
        musicJson = JsonMapper.ToJson(music);
        File.WriteAllText(Application.persistentDataPath + "/musicJsonTest.json", musicJson.ToJson());

        /*string path = Application.persistentDataPath + "/musicJson.json";
        if (!File.Exists(path))
        {
            StreamWriter sw = new StreamWriter(path);

            sw.Close();
        }
        JsonData musicJson = new JsonData();
        musicJson.Add(JsonConvert.SerializeObject(music));

        File.WriteAllText(path, musicJson.ToJson());*/
    }
    public void Loader()
    {
        string path;
        path = Application.persistentDataPath + "/musicJsonTest.json";
        if (File.Exists(path))
        {
            
            string json = File.ReadAllText(path.ToString());
            //JsonData data = new JsonData();
            JsonData data = JsonMapper.ToObject(json.ToString());
            Debug.Log(data[0]);
        }
    }
    [Serializable]
    public class MusicDataForJSon
    {
        [SerializeField]
        public int id;
        [SerializeField]
        public List<Vector3> position;
        [SerializeField]
        public MusicDataForJSon()
        {
        }

        public MusicDataForJSon(int id, List<Vector3> position)
        {
            this.id = id;
            this.position = position;
        }
    }

}

