using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuCancel : MonoBehaviour
{
    PlayerData PlayerData;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(this.gameObject.name == "Menu1Cancel")
        {
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(PlayerData.MenuList.LastIndexOf("Coffee"));
            }
        }
        if(this.gameObject.name == "Menu2Cancel")
        {
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(PlayerData.MenuList.LastIndexOf("Omrice"));
            }
            
        }
        if(this.gameObject.name == "Menu3Cancel")
        {
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(PlayerData.MenuList.LastIndexOf("Toast"));
            }
            
        }
        if(this.gameObject.name == "Menu4Cancel")
        {
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(PlayerData.MenuList.LastIndexOf("Naporitan"));
            }
            
        }
    }
}
