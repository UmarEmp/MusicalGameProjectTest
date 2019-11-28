using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{
   // public GameObject Camera;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            gameObject.transform.position += Vector3.forward * speed;
        }

        else if (Input.mouseScrollDelta.y < 0)
        {
            gameObject.transform.position -= Vector3.forward * speed;
        }
    }
}