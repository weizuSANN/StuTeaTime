using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    SoundPlayer SoundPlayer;
    GameObject SystemManager;
    PlayerData PlayerData;
    SaveAndLoad SaveAndLoad;
    GameObject EventUI;
    RestClick RestClick;
    public int Sec;
    public int Min;
    public int Hou;
    public int StartMoney;
    public int TrueStudyMoney;
    public int MoneySpan = 20;
    public int HourPlusMin;
    public int Last20Min;
    bool a;
    bool b;
    public TimeSpan TotalTime;
    public DateTime StudyStartTime;

    public TimeSpan AllTotalRestTime;
    public int AllRestMin;
    public int RestTime;
    public int RestSec;
    public int RestMin;
    public int RestHou;
    public DateTime RestStartTime;
    public TimeSpan TotalRestTime;



    // Start is called before the first frame update
    void Start()
    {
        RestClick = GameObject.Find("Rest").GetComponent<RestClick>();
        SystemManager = GameObject.Find("SystemManager");
        PlayerData = SystemManager.GetComponent<PlayerData>();
        SaveAndLoad = SystemManager.GetComponent<SaveAndLoad>();
        EventUI = GameObject.Find("EventUI");
        SoundPlayer = GameObject.Find("SoundPlayer").GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //TotalSec = TimeUntil.GetTime(DateTime.Now);
        if(PlayerData.GameMode == "Study")
        {
            //勉強中
            if(b == false)
            {
                StudyStartTime = DateTime.Now;
                StartMoney = PlayerData.Money;
                TrueStudyMoney = StartMoney;
                b = true;
            }
            TotalTime = (DateTime.Now - StudyStartTime) - AllTotalRestTime;
            Hou = TotalTime.Hours + TotalTime.Days * 24;
            Min = TotalTime.Minutes;
            Sec = TotalTime.Seconds;
            if(PlayerData.Hour <= Hou && PlayerData.Min <= Min && 0 <=Sec)
            {
                PlayerData.GameMode = "None";
            }
            // Sec = (int)(System.Math.Floor(CountTime));
            // if(Sec == 60)
            // {
            //     CountTime = 0;
            //     Min += 1;
            //     Sec = 0;
            // }
            HourPlusMin = Hou * 60 + Min;
            if(HourPlusMin / MoneySpan != Last20Min)
            {
                PlayerData.Money = StartMoney + (HourPlusMin / MoneySpan) * 100;
                SaveAndLoad.SaveOK = false;
            }
            Last20Min = HourPlusMin / MoneySpan;
            // if(Min % 20 == 0 && Sec == 0 && Min != 0)
            // {
            //     if(a == false)
            //     {
            //         PlayerData.Money += 100;
                    
            //         a = true;
            //     }
            // }
            // if(Sec == 1)
            // {
            //     a = false;
            // }

            // if(Min == 60)
            // {
            //     Hou += 1;
            //     Min = 0;
            // }
        }
        else if(PlayerData.GameMode == "None" || PlayerData.GameMode == "MenuSelect")
        {
            //勉強中でも、休憩中でもない。メニュー選択、勉強終了時など。
            Sec = 0;
            Min = 0;
            Hou = 0;
        }
        else if(PlayerData.GameMode == "Rest")
        {
            //休憩中
            AllTotalRestTime = new TimeSpan(0 , AllRestMin / 60 , AllRestMin % 60 , 0);
            TotalRestTime = DateTime.Now - RestStartTime;
            RestHou = TotalRestTime.Hours + TotalRestTime.Days * 24;
            RestMin = TotalRestTime.Minutes;
            RestSec = TotalRestTime.Seconds;
            if(TotalRestTime.Minutes >= RestTime)
            {
                PlayerData.GameMode = "Study";
                RestClick.Resting = false;
                EventUI.SetActive(true);
                SoundPlayer.SoundID = 2;
            }
        }
    }
    // void OnApplicationPause(bool pauseStatus)
    // {
    //     if(pauseStatus)
    //     {
    //         GoBackGroundTime = DateTime.Now;
    //     }
    //     else
    //     {
    //         CameInBackGroundTime = DateTime.Now;
    //     }
    // }
}
