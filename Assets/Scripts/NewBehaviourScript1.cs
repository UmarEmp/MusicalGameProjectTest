using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class NewBehaviourScript1 : MonoBehaviour
{
    public Transform GameManager;
    public List<MyObject> objects = new List<MyObject>(500);
    List<MyNestedObject> nestedObjects = new List<MyNestedObject>();


    public string json;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CollectInfo();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadInfo();
        }
    }

    public void CollectInfo()
    {
        MyWrapper myWrapper = new MyWrapper(objects);

        for (int i = 0; i < objects.Count; i++) objects.Add(null);
        for (int i = 0; i < GameManager.childCount; i++)
        {   
            
            myWrapper.objects[0].nestedObjects[i].vecPosition = GameManager.transform.GetChild(i).transform.position;
        }
        json = JsonUtility.ToJson(myWrapper);
        File.WriteAllText("C:/save.txt", json);
        Debug.Log(json);
    }
    public void LoadInfo()
    {
        
    MyWrapper myWrapper = new MyWrapper(objects);
        json = File.ReadAllText("C:/save.txt");
        JsonUtility.FromJson<MyWrapper>(json);
        for (int i = 0; i < GameManager.childCount; i++)
        {
            GameManager.transform.GetChild(i).transform.position = myWrapper.objects[0].nestedObjects[i].vecPosition;
        }
        Debug.Log(json);


    }
}
[Serializable]
public class MyWrapper
{
    [SerializeField]
    public List<MyObject> objects;
    public MyWrapper(List<MyObject> objects) {
        this.objects = objects;
    }

}
[Serializable]
public class MyObject
{
    [SerializeField]
    public List<MyNestedObject> nestedObjects;
    public MyObject(List<MyNestedObject> nestedObjects)
    {
        this.nestedObjects = nestedObjects;
    }
}
[Serializable]
public class MyNestedObject
{
    [SerializeField]
    public Vector3 vecPosition;
}



