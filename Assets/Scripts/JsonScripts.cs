using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;
using Newtonsoft.Json;
public class JsonScripts : MonoBehaviour
{
    public Transform GameManager;
    public string json;
    
    //public int id;

    // Start is called before the first frame update
    void Start()
    {
        CollectInfo();
    }

    // Update is called once per frame
      void Update()
      {
         
          if (Input.GetKeyDown(KeyCode.L))
          {
            Musics m = new Musics();
            m.Load();

          }
      }

    void CollectInfo()
    {

        Debug.Log("prrr");
        List<Noteposition> notArr = new List<Noteposition>();
        
        for (int i = 0; i < GameManager.childCount; i++)
        {
            Noteposition not = new Noteposition(GameManager.transform.GetChild(i).position);
            //not.vecPosition =  GameManager.transform.GetChild(i).position;
            Debug.Log(not.vecPosition + " qqq");
            notArr.Add(not);
        }
        Debug.Log(notArr.Count+" notArr");

        Musics myMusicObject = new Musics(notArr);



    }
    


    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
[Serializable]
public class Musics
{
    [SerializeField]
    public List<Vector3> notposition = new List<Vector3>();

    public Musics(List<Noteposition> notposition)
    {
        foreach (Noteposition not in notposition)
        {
            this.notposition.Add(not.vecPosition);
        }
        string path = Application.persistentDataPath + "/data.json";
        if (!File.Exists(path))
        {
            StreamWriter sw = new StreamWriter(path);

            sw.Close();
        }
        JsonData data = new JsonData();

        foreach (Noteposition not in notposition)
        {

            data.Add(JsonConvert.SerializeObject(not));
        }

        File.WriteAllText(path, data.ToJson());
    }
    public Musics() { }
    public void Load()
    {
        string path = Application.persistentDataPath + "/data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //JsonData data = new JsonData();
            JsonData data = JsonMapper.ToObject(json);
            JsonData d =new JsonData();
            Debug.Log(data.Count + "pr");
            for (int i = 0; i < data.Count; i++)
            {
               // Debug.Log(data[i]);
            }
            // float[] ok = new float();
           // Debug.Log(data[0]);
           var list = JsonConvert.DeserializeObject<List<Noteposition>>(data.ToJson());
            //d.Add(JsonConvert.DeserializeObject<List<Noteposition>>(data.ToJson()));
           // Vector3 vec = list[0].vecPosition.normalized;
            //Debug.Log(list[0].vecPosition);

        }
    }

}
[Serializable]
public class Noteposition
{
    public Vector3 vecPosition;
    public Noteposition() { }
    public Noteposition(Vector3 vec)
    {
        vecPosition = vec;
    }
}


