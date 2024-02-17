using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeParse : MonoBehaviour
{
    Image Image;
    PlayerData PlayerData;
    Timer Timer;
    public int TimeSpan;
    public int LastMin;
    public int i = 1;
    public List<Sprite> Sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        Image = this.gameObject.GetComponent<Image>();
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.GameMode == "Study")
        {
            TimeSpan = (int)(System.Math.Ceiling((float)(PlayerData.Hour * 60 + PlayerData.Min) / 3.0f));
            if(LastMin != Timer.HourPlusMin / TimeSpan)
            {
                Image.sprite = Sprites[Timer.HourPlusMin / TimeSpan];
            }
            LastMin = Timer.HourPlusMin / TimeSpan;
        }
        
    }
}
