using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public AudioSource s;

    public Text soundText;
    public bool soundIsON;

    private void Start()
    {
        soundText.text = "ON";
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("cube")) 
        {
            isOnSound(false);
            Destroy(other.gameObject);
            return;
        }
        else 
        {
            isOnSound(true);
            return;
        }
    }
    
    public bool isOnSound(bool isON) 
    {
        if (isON == true) 
        {
            soundText.text = "ON";
            s.volume = 1f;
        }
        else 
        {
            soundText.text = "OFF";
            s.volume = 0.1f;
        }
        return soundIsON;
    }

}
