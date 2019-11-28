using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentForLevel : MonoBehaviour
{
    Vector3 dist;
    float posX;
    float posY;

    /*public float radLimit;
        float maxRadX;
        float maxRadY;
    float Radian;
    float Degre;*/

    private void OnMouseDown()
    {

        /*
        Radian = Degre * Mathf.PI / 180;
        maxRadX = radLimit * Mathf.Cos(Radian);
        maxRadY = radLimit * Mathf.Sin(Radian);
        posX = Mathf.Clamp(posX, -maxRadX, maxRadX);
        posY = Mathf.Clamp(posX, -maxRadY, maxRadY);*/
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
    }

    private void OnMouseDrag()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }
}
/*public class TileControl : MonoBehaviour
{

    public float[] ZPosition;
    public GameObject[] Tiles;
    private int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ZPosition.Length; i++)
        {

            Tiles[i].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, ZPosition[i]);
        }
    }
}*/
