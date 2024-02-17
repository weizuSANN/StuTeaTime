using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    RectTransform Rect;
    public GameObject TimerObject;
    public Timer _Timer;
    // Start is called before the first frame update
    void Start()
    {
        TimerObject = GameObject.Find("Timer");
        Rect = this.gameObject.GetComponent<RectTransform>();
        _Timer = TimerObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name == "sec")
        {
            Rect.localRotation = Quaternion.Euler(0 , 0  , -1 * _Timer.Sec * 6);
        }
        else if(this.gameObject.name == "min")
        {
            Rect.localRotation = Quaternion.Euler(0 , 0  , -1 * _Timer.Min * 6);
        }
        else if(this.gameObject.name == "hour")
        {
            Rect.localRotation = Quaternion.Euler(0 , 0  , -1 * _Timer.Hou * 30);
        }
    }
}
