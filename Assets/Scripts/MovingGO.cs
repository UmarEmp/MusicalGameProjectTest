using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi;
using Melanchall.DryWetMidi.Smf;

public class MovingGO : MonoBehaviour
{
    int i = 0;

    void Update()
    {   
       // if()
        transform.Translate(0, 0, -2f*Time.deltaTime);
      /*  if (transform.GetChild(i).transform.position.z < Mathf.Abs(transform.position.z))
        {
            transform.GetChild(i).gameObject.SetActive(false); i++;
        }*/
    }
}
