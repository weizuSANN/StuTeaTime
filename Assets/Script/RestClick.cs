using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestClick : MonoBehaviour
{
    PlayerData PlayerData;
    Timer Timer;
    public int Price;
    public bool Resting;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(Resting == false)
        {
            if(PlayerData.MenuList.Count != 0)
            {
                if(PlayerData.MenuList[0] == "Coffee")
                {
                    Timer.StartMoney -= 100;
                    Timer.RestTime = 3;
                    Timer.AllRestMin += 3;
                }
                else if(PlayerData.MenuList[0] == "Omrice")
                {
                    Timer.StartMoney -= 200;
                    Timer.RestTime = 6;
                    Timer.AllRestMin += 6;
                }
                else if(PlayerData.MenuList[0] == "Toast")
                {
                    Timer.StartMoney -= 500;
                    Timer.RestTime = 15;
                    Timer.AllRestMin += 15;
                }
                else if(PlayerData.MenuList[0] == "Naporitan")
                {
                    Timer.StartMoney -= 1000;
                    Timer.RestTime = 30;
                    Timer.AllRestMin += 30;
                }
            }
            PlayerData.GameMode = "Rest";
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(0);
            }
            Timer.RestStartTime = DateTime.Now;
            PlayerData.Money = Timer.StartMoney + (Timer.HourPlusMin / Timer.MoneySpan) * 100;
            Resting = true;
        }
    }
}
