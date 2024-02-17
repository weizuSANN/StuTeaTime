using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TotalMenuOrder : MonoBehaviour
{
    CheckOut CheckOut;
    PlayerData PlayerData;
    Text Text;
    public int AllMoney;
    // Start is called before the first frame update
    void Start()
    {
        CheckOut = GameObject.Find("V").GetComponent<CheckOut>();
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
        Text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        AllMoney = AllMoney = PlayerData.MenuList.Count(n => n == "Coffee") * 100 + PlayerData.MenuList.Count(n => n == "Omrice") * 200 + PlayerData.MenuList.Count(n => n == "Cat") * 500 + PlayerData.MenuList.Count(n => n == "Shark") * 1000;;
        Text.text = "合計金額：" + AllMoney + "円";
    }
}
