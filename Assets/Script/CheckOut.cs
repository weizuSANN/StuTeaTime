using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CheckOut : MonoBehaviour
{
    public AudioClip SE;
    GameObject SystemManager;
    PlayerData PlayerData;
    TextScript TextScript;
    Text HourLabel;
    Text MinLabel;
    int Hour;
    int Min;
    GameObject TimeSelectPop;
    GameObject MoneyOverPop;
    AudioSource AudioSource;
    public int AllMoney;
    // Start is called before the first frame update
    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        PlayerData = SystemManager.GetComponent<PlayerData>();
        TextScript = SystemManager.GetComponent<TextScript>();
        HourLabel = GameObject.Find("HourLabel").GetComponent<Text>();
        MinLabel = GameObject.Find("MinLabel").GetComponent<Text>();
        AudioSource = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        TimeSelectPop = GameObject.Find("TimeSelectPop");
        MoneyOverPop = GameObject.Find("MoneyOverPop");
        MoneyOverPop.SetActive(false);
        TimeSelectPop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        Hour = int.Parse(HourLabel.text);
        Min = int.Parse(MinLabel.text);
        if(Hour == 0 && Min == 0)
        {
            TimeSelectPop.SetActive(true);
        }
        else
        {
            AllMoney = PlayerData.MenuList.Count(n => n == "Coffee") * 100 + PlayerData.MenuList.Count(n => n == "Omrice") * 600 + PlayerData.MenuList.Count(n => n == "Toast") * 300 + PlayerData.MenuList.Count(n => n == "Naporitan") * 400;
            if(AllMoney > PlayerData.Money)
            {
                MoneyOverPop.SetActive(true);
            }
            else
            {
                PlayerData.OrderList = PlayerData.MenuList;
                PlayerData.Hour = Hour;
                PlayerData.Min = Min;
                PlayerData.GameMode = "Study";
            }
        }
        AudioSource.PlayOneShot(SE);
    }
    
}
