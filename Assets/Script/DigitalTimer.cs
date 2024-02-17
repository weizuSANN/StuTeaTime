using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalTimer : MonoBehaviour
{
    public Timer Timer;
    public Text TimerText;
    string Time;
    // Start is called before the first frame update
    void Start()
    {
        Timer = this.gameObject.GetComponent<Timer>();
        TimerText = GameObject.Find("TimerStrings").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Time = "";
        if(Timer.Hou < 10)
        {
            Time += "0" + Timer.Hou.ToString() + ":";
        }
        else
        {
            Time += Timer.Hou.ToString() + ":";
        }
        if(Timer.Min < 10)
        {
            Time += "0" + Timer.Min.ToString() + ":";
        }
        else
        {
            Time += Timer.Min.ToString() + ":";
        }
        if(Timer.Sec < 10)
        {
            Time += "0" + Timer.Sec.ToString();
        }
        else
        {
            Time += Timer.Sec.ToString();
        }
        TimerText.text = "現在の勉強時間\n" + Time;
    }
}
