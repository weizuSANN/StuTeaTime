using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOrder : MonoBehaviour
{
    public AudioClip SE;
    PlayerData PlayerData;
    AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.Find("SystemManager").GetComponent<PlayerData>();
        AudioSource = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(this.gameObject.name == "Menu1Add")
        {
            PlayerData.MenuList.Add("Coffee");
        }
        if(this.gameObject.name == "Menu2Add")
        {
            PlayerData.MenuList.Add("Omrice");
        }
        if(this.gameObject.name == "Menu3Add")
        {
            PlayerData.MenuList.Add("Toast");
        }
        if(this.gameObject.name == "Menu4Add")
        {
            PlayerData.MenuList.Add("Naporitan");
        }

        AudioSource.PlayOneShot(SE);
    }
}
