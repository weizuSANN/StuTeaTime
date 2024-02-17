using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderSelectable : MonoBehaviour
{
    GameObject SystemManager;
    PlayerData PlayerData;
    SaveAndLoad SaveAndLoad;
    GameObject Menu1;
    GameObject Menu2;
    GameObject Menu3;
    GameObject Menu4;
    // Start is called before the first frame update
    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        PlayerData = SystemManager.GetComponent<PlayerData>();
        SaveAndLoad = SystemManager.GetComponent<SaveAndLoad>();
        Menu1 = GameObject.Find("Menu1");
        Menu2 = GameObject.Find("Menu2");
        Menu3 = GameObject.Find("Menu3");
        Menu4 = GameObject.Find("Menu4");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.GameMode == "MenuSelect")
        {
            Menu1.SetActive(true);
            if(SaveAndLoad.SaveData.OrderMenu.Contains("オムライス"))
            {
                Menu2.SetActive(true);
            }
            else
            {
                Menu2.SetActive(false);
            }
            if(SaveAndLoad.SaveData.OrderMenu.Contains("トースト"))
            {
                Menu3.SetActive(true);
            }
            else
            {
                Menu3.SetActive(false);
            }
            if(SaveAndLoad.SaveData.OrderMenu.Contains("ナポリタン"))
            {
                Menu4.SetActive(true);
            }
            else
            {
                Menu4.SetActive(false);
            }
        }
    }
}
