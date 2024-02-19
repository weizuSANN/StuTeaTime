using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReceiptTextScript : MonoBehaviour
{
    Text Text;
    Timer Timer;
    PlayerData PlayerData;
    // Start is called before the first frame update
    void Start()
    {
        Text = this.gameObject.GetComponent<Text>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "スタティータイム\n" + "勉強時間：" + Timer.TotalTime.Hours + "時間" + Timer.TotalTime.Minutes + "分" + Timer.TotalTime.Seconds + "秒" + "\n" + "獲得金" + (PlayerData.Money - Timer.TrueStudyMoney) + "円" + "\n";
        if(PlayerData.OrderList.Contains("Coffee"))
        {
            Text.text += "コーヒー　" + PlayerData.MenuList.Count(n => n == "Coffee") + "\n";
        }
        if(PlayerData.OrderList.Contains("Omrice"))
        {
            Text.text += "オムライス　" + PlayerData.MenuList.Count(n => n == "Omrice") + "\n";
        }
        if(PlayerData.OrderList.Contains("Toast"))
        {
            Text.text += "トースト　" + PlayerData.MenuList.Count(n => n == "Toast") + "\n";
        }
        if(PlayerData.OrderList.Contains("Naporitan"))
        {
            Text.text += "ナポリタン　" + PlayerData.MenuList.Count(n => n == "Naporitan") + "\n";
        }
        Text.text += "休憩時間：" + Timer.AllTotalRestTime;
    }
}
