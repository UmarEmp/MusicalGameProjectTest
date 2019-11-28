using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    public Vector3 dir;

    public float speed;

    public GameObject prefabs;

    

    private void Update()
    {
        transform.position -= Vector3.forward * Time.deltaTime * speed ;    
    }


    

}