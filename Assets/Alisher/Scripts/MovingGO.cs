using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGO : MonoBehaviour
{
    public int i = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        i = transform.childCount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if()
        transform.Translate(0, 0, -2 * Time.deltaTime *speed);
    }
}
