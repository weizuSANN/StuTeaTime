using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR : MonoBehaviour
{
    public bool ADC;
    public GameObject ClockAnalog;
    public GameObject ClockDigital;
    // Start is called before the first frame update
    void Start()
    {
        ClockDigital = GameObject.Find("ClockDigital");
        ClockAnalog = GameObject.Find("ClockAnalog");
    }

    // Update is called once per frame
    void Update()
    {
        if(ADC == false)
        {
            ClockAnalog.SetActive(true);
            ClockDigital.SetActive(false);
        }
        else if(ADC == true)
        {
            ClockAnalog.SetActive(false);
            ClockDigital.SetActive(true);
        }
    }
}
