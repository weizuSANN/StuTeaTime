using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOutput : MonoBehaviour
{
    public AudioClip SE;
    AudioSource AudioSource;
    GameObject TextOuter;
    Text Text;
    [TextArea(1 , 30)]
    public string Content;
    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        TextOuter = GameObject.Find("TextOuter");
        Text = GameObject.Find("Text").GetComponent<Text>();
        AudioSource = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(a == false)
        {
            TextOuter.SetActive(false);
            a = true;
        }
    }
    public void OnClick()
    {
        if(this.gameObject.name == "Menu")
        {
            TextOuter.SetActive(true);
            string Menu;
            SaveAndLoad SaveAndLoad = GameObject.Find("TitleManager").GetComponent<SaveAndLoad>();
            SaveData Load = new SaveData();
            if(SaveAndLoad.ExistSaveData() == true)
            {
                Load = SaveAndLoad.Load();
            }
            else
            {
                Load.Coins = 0;
                Load.OrderMenu.Add("？？？");
            }
            Menu = "注文できるメニュー\n";
            for(int i = 0; i <= Load.OrderMenu.Count - 1; i++)
            {
                Menu += Load.OrderMenu[i] + "\n";
            }
            Menu += "現在の所持金\n" + Load.Coins + "\n";
            Text.text = Menu;
        }
        else if(this.gameObject.name == "HowToUse")
        {
            TextOuter.SetActive(true);
            Text.text = Content;
        }
        else if(this.gameObject.name == "Credit")
        {
            TextOuter.SetActive(true);
            Text.text = Content;
        }
        AudioSource.PlayOneShot(SE);
    }
}
