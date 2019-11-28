using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Camera Cm;
    Vector3 offset;

    public Test soundScript;

    public Text SensT;
    public Slider sliderSens;
    [Range(2,20)]
    public float speed = 5f;
    public VariableJoystick joystick;

    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    

    private void Start()
    {
        sliderSens.value = 10f;
       // offset = new Vector3(Mathf.Abs(offset.x), offset.y,offset.z-5);
    }

    private void Update()
    {
      
        SensT.text = speed.ToString();

        speed = sliderSens.value;
    }


    void FixedUpdate()
    {
        Move();
        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y, minY, maxY);
        curPos.x = Mathf.Clamp(transform.localPosition.x, minX, maxX);
        transform.localPosition = curPos;
    }
    private void LateUpdate()
    {
     //   Cm.transform.position = transform.position + offset ;
    }

    void Move()
    {
    Vector3 dir = Vector3.up * joystick.Vertical + Vector3.right * joystick.Horizontal;
    transform.Translate(dir * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            soundScript.isOnSound(true);
            Destroy(other.gameObject);
        }
    }
}
