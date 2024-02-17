using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowMoneyCounter : MonoBehaviour
{
    PlayerData PlayerData;
    Text NowMoneyText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
        if(this.gameObject.name == "NowMoney")
        {
            NowMoneyText = GameObject.Find("NowMoneyText").GetComponent<Text>();
        }
        else
        {
            NowMoneyText = GameObject.Find("NowMoneyText2").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        NowMoneyText.text = "所持金\n" + PlayerData.Money;
    }
}
