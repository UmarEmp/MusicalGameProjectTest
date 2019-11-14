using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class JsonScripts : MonoBehaviour
{
    public Transform GameManager;
    public string  json;
    public int id;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  /*  void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CollectInfo();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadInfo();
        }
    }*/
    [Serializable]
    public class MusicalLevel {
        public Vector3 vecPosition;
    }




    public void CollectInfo()
    {
        MusicalLevel[] musicalLevel = new MusicalLevel[100];
        for (int i = 0; i < GameManager.childCount; i++)
        {
            musicalLevel[i].vecPosition = transform.position;      
        }
        json = JsonHelper.ToJson(musicalLevel);
        File.WriteAllText("C:/save.txt", json);
        Debug.Log(json);
    }
   /* public void LoadInfo()
    {
        
        var json1 = File.ReadAllText("C:/save.txt");
        JsonUtility.FromJson(json, MusicalLevel[0]);
        for (int i = 0; i < GameManager.childCount; i++)
        {
            GameManager.transform.GetChild(i).transform.position = musicalLevel[i].vecPosition;
        }
        Debug.Log(json);
    }*/
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

