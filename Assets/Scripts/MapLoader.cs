using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Newtonsoft.Json;

public class MapLoader : MonoBehaviour
{
    // Start is called before the first frame update
  //  public JsonScripts js;
    public List<Vector3> ObjPos;
  
    public Transform prefabs;

    void Start()
    {
       
        //Musics m = new Musics();
        //m.Load();
        Debug.Log("pr123456" + ObjPos.Count);

        for (int i = 0; i < ObjPos.Count; i++)
        {
            Debug.Log(ObjPos[i]);
            var newObj = Instantiate(prefabs, ObjPos[i], Quaternion.Euler(0, 0, 0), transform);
        }
        //m.Load();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
