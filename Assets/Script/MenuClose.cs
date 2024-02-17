using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClose : MonoBehaviour
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
    public void MenuX()
    {
        PlayerData.GameMode = "Rest";
    }
}
