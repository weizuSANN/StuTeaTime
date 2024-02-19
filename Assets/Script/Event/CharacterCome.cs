using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CharacterCome : MonoBehaviour
{
    public int ID;
    public int EventSpan;
    public int Count;
    int LastMin;
    Timer Timer;
    TextScript TextScript;
    GameObject SystemManager;
    SaveAndLoad SaveAndLoad;
    PlayerData PlayerData;
    public List<Sprite> Sprites = new List<Sprite>();

    //ぶーる
    bool Cat;
    bool Bird;
    bool Cus;
    //まとまり
    GameObject Master;
    GameObject Customer;
    GameObject BlackCat;
    GameObject WhiteCat;
    GameObject ParentBird;
    GameObject ChildBird;
    GameObject Clover;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        SystemManager = GameObject.Find("SystemManager");
        TextScript = SystemManager.GetComponent<TextScript>();
        SaveAndLoad = SystemManager.GetComponent<SaveAndLoad>();
        PlayerData = SystemManager.GetComponent<PlayerData>();

        Master = GameObject.Find("Master");
        Customer = GameObject.Find("Customer");
        BlackCat = GameObject.Find("BlackCat");
        WhiteCat = GameObject.Find("WhiteCat");
        ParentBird = GameObject.Find("ParentBird");
        ChildBird = GameObject.Find("ChildBird");
        Clover = GameObject.Find("Clover");
        Master.SetActive(false);
        Customer.SetActive(false);
        BlackCat.SetActive(false);
        WhiteCat.SetActive(false);
        ParentBird.SetActive(false);
        ChildBird.SetActive(false);
        Clover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ID = Random.Range(0 , 3);
        if(Timer.HourPlusMin / EventSpan != LastMin)
        {
            StartCoroutine(Event(ID));
        }
        LastMin = Timer.HourPlusMin / EventSpan;
    }
    IEnumerator Event(int ID)
    {
        if(Cus == true)
        {
            ID = 1;
        }
        if(Cat == true)
        {
            ID = 2;
        }
        if(Bird == true)
        {
            ID = 1;
        }
        if(Cat == true && Bird == true)
        {
            ID = 114514;
            yield return null;
        }
        if(ID == 0)
        {
            //客
            if(SaveAndLoad.SaveData.EventProgress.Master >= 1 && SaveAndLoad.SaveData.EventProgress.Bird >= 2 && SaveAndLoad.SaveData.TotalCount > 5)
            {
                //客&白猫
                Customer.SetActive(true);
                RectTransform CuRect = Customer.GetComponent<RectTransform>();
                Image CuImg = Customer.GetComponent<Image>();
                CuImg.sprite = Sprites[2];
                Vector3 start = new Vector3(1297 , -689 , 0);
                CuRect.localPosition = start;
                for(int i= 0; i <= 255; i++)
                {
                    CuRect.localPosition += new Vector3(-4.8f , 2.8f);
                    yield return new WaitForSeconds(0.01f);
                }
                CuImg.sprite = Sprites[3];
            }
            else
            {
                ID = 1;
            }
        }
        if(ID == 1)
        {
            //ねこ
            if(SaveAndLoad.SaveData.EventProgress.Cat < 3)
            {
                BlackCat.SetActive(true);
                RectTransform BCRect = BlackCat.GetComponent<RectTransform>();
                Image BCImg = BlackCat.GetComponent<Image>();
                BCImg.sprite = Sprites[4];
                Vector3 start = new Vector3(1297 , -689 , 0);
                BCRect.localPosition = start;
                for(int i= 0; i <= 255; i++)
                {
                    BCRect.localPosition += new Vector3(-6 , 2);
                    yield return new WaitForSeconds(0.01f);
                }
                BCImg.sprite = Sprites[5];
            }
            else
            {
                //黒猫、白猫両方
                BlackCat.SetActive(true);
                WhiteCat.SetActive(true);
                RectTransform BCRect = BlackCat.GetComponent<RectTransform>();
                RectTransform WCRect = WhiteCat.GetComponent<RectTransform>();
                Image BCImg = BlackCat.GetComponent<Image>();
                Image WCImg = WhiteCat.GetComponent<Image>();
                BCImg.sprite = Sprites[4];
                WCImg.sprite = Sprites[6];
                Vector3 start1 = new Vector3(1297 , -689 , 0);
                Vector3 start2 = new Vector3(1600 , -690 , 0);//白
                BCRect.localPosition = start1;
                WCRect.localPosition = start2;
                for(int i= 0; i <= 255; i++)
                {
                    BCRect.localPosition += new Vector3(-6 , 2);
                    WCRect.localPosition += new Vector3(-6 , 2);//
                    yield return new WaitForSeconds(0.01f);
                }
                BCImg.sprite = Sprites[5];
                WCImg.sprite = Sprites[7];
            }
            Cat = true;
        }
        if(ID == 2)
        {
            if(SaveAndLoad.SaveData.EventProgress.Bird ==  0)
            {
                //親のみ
                ParentBird.SetActive(true);
                Clover.SetActive(true);
                RectTransform PBRect = ParentBird.GetComponent<RectTransform>();
                Image PBImg = ParentBird.GetComponent<Image>();
                RectTransform CloverRect = Clover.GetComponent<RectTransform>();
                Image ClImg = Clover.GetComponent<Image>();
                PBImg.sprite = Sprites[8];
                ClImg.sprite = Sprites[0];
                Vector3 start = new Vector3(-1583 , 762 , 0);
                PBRect.localPosition = start;
                CloverRect.localPosition = start + new Vector3(50 , -50 , 0);
                for(int i= 0; i <= 255; i++)
                {
                    PBRect.localPosition += new Vector3(3 , -4);//調整！調整！さっさと調整！殺すぞ！！
                    CloverRect.localPosition += new Vector3(3 , -4);
                    yield return new WaitForSeconds(0.01f);
                }
                PBImg.sprite = Sprites[9];
                CloverRect.localPosition += new Vector3(50 , -30 , 0);
                
            }
            else if(SaveAndLoad.SaveData.EventProgress.Master >= 1 && SaveAndLoad.SaveData.EventProgress.Bird == 1)
            {
                //親子
                ParentBird.SetActive(true);
                ChildBird.SetActive(true);
                Clover.SetActive(true);
                RectTransform PBRect = ParentBird.GetComponent<RectTransform>();
                Image PBImg = ParentBird.GetComponent<Image>();
                RectTransform CBRect = ChildBird.GetComponent<RectTransform>();
                Image CBImg = ChildBird.GetComponent<Image>();
                RectTransform CloverRect = Clover.GetComponent<RectTransform>();
                Image ClImg = Clover.GetComponent<Image>();
                ClImg.sprite = Sprites[0];
                PBImg.sprite = Sprites[8];
                CBImg.sprite = Sprites[10];
                Vector3 start1 = new Vector3(-1583 , 762 , 0);
                Vector3 start2 = new Vector3(-1783 , 962 , 0);
                PBRect.localPosition = start1;
                CBRect.localPosition = start2;
                CloverRect.localPosition = start1 + new Vector3(50 , -50 , 0);
                for(int i= 0; i <= 255; i++)
                {
                    PBRect.localPosition += new Vector3(3 , -3);//調整！調整！さっさと調整！殺すぞ！！
                    CBRect.localPosition += new Vector3(3 , -4);//調整！調整！さっさと調整！殺すぞ！！
                    CloverRect.localPosition += new Vector3(3 , -4);
                    yield return new WaitForSeconds(0.01f);
                }
                PBImg.sprite = Sprites[9];
                CBImg.sprite = Sprites[11];
                CloverRect.localPosition += new Vector3(50 , -30 , 0);
            }
            Bird = true;
        }
    }
}
