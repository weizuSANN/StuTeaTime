using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerData : MonoBehaviour
{
    GameObject TextUI;
    GameObject StudyUI;
    GameObject MenuUI;
    GameObject EndingUI;
    Image Moon;
    Image Fade;
    public Color FadeColor;
    TextScript TextScript;
    SaveAndLoad SaveAndLoad;
    SoundPlayer SoundPlayer;
    public SaveData SaveData;
    public List<string> OrderMenu = new List<string>();
    public List<string> MenuList = new List<string>();
    string FilePath;
    public bool First = false;
    public string GameMode = "None";
    public int Money;
    public int Hour;
    public int Min;
    public string LastGameMode;
    bool a;
    public int TotalStamp;
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        TextUI = GameObject.Find("TextUI");
        StudyUI = GameObject.Find("StudyUI");
        MenuUI = GameObject.Find("MenuUI");
        EndingUI = GameObject.Find("EndingUI");
        TextScript = this.gameObject.GetComponent<TextScript>();
        SaveAndLoad = this.gameObject.GetComponent<SaveAndLoad>();
        Moon = GameObject.Find("Moon").GetComponent<Image>();
        Fade = GameObject.Find("Fade").GetComponent<Image>();
        FadeColor = Fade.color;
        SoundPlayer = GameObject.Find("SoundPlayer").GetComponent<SoundPlayer>();
        EndingUI.SetActive(false);
        StartCoroutine("StartIn");
    }

    // Update is called once per frame
    void Update()
    {
        if(LastGameMode == "Study" && GameMode == "None")
        {
            if(a == false)
            {
                StartCoroutine("LastOrder");
            }
        }
        else
        {
            a = false;
        }
        if(GameMode == "MenuSelect")
        {
            MenuUI.SetActive(true);
        }
        else
        {
            MenuUI.SetActive(false);
        }
        LastGameMode = GameMode;
    }

    IEnumerator StartIn()
    {
        yield return new WaitUntil(() => SaveAndLoad.LoadEnd);
        SoundPlayer.SoundID = 2;
        //ロード
        //上書き
        if(First == false)
        {
            //初回起動時
            StudyUI.SetActive(false);
            MenuUI.SetActive(false);
            TextScript.Message("マスター" , "おや。始めてご来店のお客さんかい？<>うちは他所の喫茶店と違って勉強に集中してもらう<>ことをコンセプトにしているんだ。<>これからも足繁く通ってほしいからね。<>サービスでコーヒー一杯無料にしといてあげよう。" , 0.05f);
            OrderMenu.Add("コーヒー");
            Money += 100;
        }
        else
        {
            //2回目以降
            StudyUI.SetActive(false);
            MenuUI.SetActive(false);
            TextScript.Message("マスター" , "いらっしゃい。ご注文は？" , 0.05f);
        }
        yield return new WaitUntil(() => TextScript.IsTextEnd);
        First = true;
        StudyUI.SetActive(true);
        GameObject.Find("ClockDigital").SetActive(false);
        
    }
    IEnumerator LastOrder()
    {
        a = true;
        SoundPlayer.SoundID = 1;
        TextScript.Message("マスター" , "遅くまでお疲れ様。<>そろそろ閉店の時間だ。勉強は切り上げて帰りな。<>ほら。カード出しな。今日の分のスタンプだよ。<>次回出してもらえればコーヒー一杯サービスするからさ。<>これからもご贔屓にお願いね" , 0.05f);
        yield return new WaitUntil(() => TextScript.IsTextEnd);
        //スタンプ
        //yield return new waituntil(() => スタンプ押し完了)
        TotalStamp += 1;
        //if(TotalStamp % 4 = 0)
        // for(int i = 0; i <= 16; i++)
        // {
        //     if(TotalStamp / i == 1)
        //     {
        //         if(i == 1)
        //         {
        //             //追加メニューイベント
        //         }
        //         else if(i == 2)
        //         {
        //             //追加メニューイベント
        //         }
        //     }
        // }
        //表表示
        //シーンリロード
        EndingUI.SetActive(true);
        for(int i = 0; i <= 255; i++)
        {
            Debug.Log("a");
            Moon.color = new Color(255 , 255 , 255 , (float)i / 255.0f);
            Fade.color = new Color(0 , 0 , 0 , (float)i / 255.0f);
            yield return new WaitForSeconds(0.01f);
        }
        //クリアの表示
        //yield return new waituntil(() => 確認ボタンが押される)
        //シーンリロード
    }
}
