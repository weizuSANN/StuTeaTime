using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockActive : MonoBehaviour
{
    GameObject ClockDigital;
    GameObject ClockAnalog;
    // Start is called before the first frame update
    void Start()
    {
        ClockDigital = GameObject.Find("ClockDigital");
        ClockAnalog = GameObject.Find("ClockAnalog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(this.gameObject.name == "ClockDigital")
        {
            ClockDigital.SetActive(false);
            ClockAnalog.SetActive(true);
        }
        else if(this.gameObject.name == "ClockAnalog")
        {
            ClockDigital.SetActive(true);
            ClockAnalog.SetActive(false);
        }
    }
}
