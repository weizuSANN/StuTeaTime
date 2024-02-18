using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestClick : MonoBehaviour
{
    PlayerData PlayerData;
    Timer Timer;
    public int Price;
    public bool Resting;
    GameObject EventUI;
    CharacterCome CharacterCome;
    TextScript TextScript;
    GameObject SystemManager;
    SaveAndLoad SaveAndLoad;
    // Start is called before the first frame update
    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        PlayerData = SystemManager.GetComponent<PlayerData>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        EventUI = GameObject.Find("EventCanvas");
        CharacterCome = GameObject.Find("EventUI").GetComponent<CharacterCome>();
        TextScript = SystemManager.GetComponent<TextScript>();
        SaveAndLoad = SystemManager.GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(Resting == false)
        {
            if(PlayerData.MenuList.Count != 0)
            {
                if(PlayerData.MenuList[0] == "Coffee")
                {
                    Timer.StartMoney -= 100;
                    Timer.RestTime = 3;
                    Timer.AllRestMin += 3;
                    if(SaveAndLoad.SaveData.EventProgress.Master == 0 && SaveAndLoad.SaveData.TotalCount > 2)
                    {
                        TextScript.Message("マスター" , "どうも。<>少しお話、いいかい？<>実は最近悩んでいることがあって…<>というのも、客足があまり伸びなくてね…<>いや。もちろん貴方がよく来てくれているのは<>うれしいんだが…<>やっぱりもう少し常連さんを増やしたいもんだ…<>…すまないね。こんな辛気臭い話してしまって。<>話聞いてくれてありがとうね。" , 0.08f , true);
                        SaveAndLoad.SaveData.EventProgress.Master += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Master == 1 && SaveAndLoad.SaveData.TotalCount > 5  && SaveAndLoad.SaveData.EventProgress.Bird == 2)
                    {
                        TextScript.Message("常連客" , "こんにちは。<>ああ。いえ。怪しい者じゃないですよ。<>私は最近よくここに通ってるものです。<>あなた、いつもこの席に座っていらっしゃいますよね<>いえ。私がこの店に通いだしたときから<>いらっしゃるものですから。<>少し話してみたくなったんです。<>まあ、私も最近よくこの店に通っていましてね。<>今後も、お会いしたらよろしくお願いします。" , 0.05f , true);
                        SaveAndLoad.SaveData.EventProgress.Master += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Master == 2 && SaveAndLoad.SaveData.TotalCount > 8)
                    {
                        TextScript.Message("マスター" , "どうも。<>また少し、お話、いいかな？<>あれ以来、結構うちも客足が増えてね。<>うれしい限りだよ。<>なかでも、貴方は一番の古客だからね。<>宣伝してくれたのかなんなのかわからないけどさ…<>ありがとね…" , 0.05f , true);
                        SaveAndLoad.SaveData.EventProgress.Master += 1;
                    }
                }
                else if(PlayerData.MenuList[0] == "Omrice")
                {
                    Timer.StartMoney -= 200;
                    Timer.RestTime = 6;
                    Timer.AllRestMin += 6;
                }
                else if(PlayerData.MenuList[0] == "Toast")
                {
                    Timer.StartMoney -= 500;
                    Timer.RestTime = 15;
                    Timer.AllRestMin += 15;
                    if(SaveAndLoad.SaveData.EventProgress.Bird == 0 && SaveAndLoad.SaveData.TotalCount > 3)
                    {
                        TextScript.Message("青い鳥" , "いつも勉強頑張っていますね<>あなたは誰？って顔していますね。<>あなたはわからないかもしれないけど、<>よく窓からあなたの勉強は覗かせてもらっています。<>うちの子も見習ってほしいくらいだわ。<>というのもね？うちの子、鳥なのにまだ飛べないのよ。<>早く飛べるようになってほしいものだわ。<>せっかくだし、うちの子の練習航路は<>この店にしましょう！<>そんなわけなので、もしかしたらうちの子と<>お会いするかもしれないわ。<>もしあったらよろしくお願いしますね。<>あの子、おっちょこちょいだから。" , 0.05f , true);
                        SaveAndLoad.SaveData.EventProgress.Bird += 1;
                        //会話始まったら勉強時間リセットされるバグあり.
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Bird == 1 && SaveAndLoad.SaveData.TotalCount > 4)
                    {
                        TextScript.Message("翠の鳥" , "あっどーも。<>うちのかーちゃんがお世話になってるっす！<>いやー。うちのかーちゃんうるさいでしょ。<>ぴーちくぱーちく勉強しろって。<>家でもあんな調子なんすよ。<>お宅のお母さんはどうっすか？<>そっかあ…<>まあ！お互い頑張りましょ！" , 0.05f , true);
                        SaveAndLoad.SaveData.EventProgress.Bird += 1;
                    }
                }
                else if(PlayerData.MenuList[0] == "Naporitan")
                {
                    Timer.StartMoney -= 1000;
                    Timer.RestTime = 30;
                    Timer.AllRestMin += 30;
                    if(SaveAndLoad.SaveData.EventProgress.Cat == 0 && SaveAndLoad.SaveData.TotalCount > 4 && SaveAndLoad.SaveData.EventProgress.Master >= 1)
                    {
                        TextScript.Message("黒猫" , "よう。勉強、はかどってるかい？<>おっと。いけね。勉強中か…？ってなんだ。休憩中か<>勉強中にちょっかいかけると<>マスターから怒られるからよ。<>ま、ともかくだ。おいらのことは知ってるだろ？<>しらねーってのかい。<>常連なんだから名前くらい覚えろっての<>おいらは黒猫のクロだ。<>おいら、最近ひそかに想いを寄せてる子がいてな<>お前じゃない常連の連れてくる白猫ちゃんだ<>おいらの恋を成就させるために<>手伝っちゃくれねえか？" , 0.05f , true);
                        SaveAndLoad.SaveData.EventProgress.Cat += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Cat == 1 && SaveAndLoad.SaveData.TotalCount > 5)
                    {
                        TextScript.Message("白猫" , "あら。こんにちは。どうしたのかしら人間さん。<>私？私は白猫のシロよ。<>えっ？紹介したい猫がいるって？<>あの黒猫の子？<>うれしい！私もあの子きになってたの！<>こんど会ったらお話してみるわね！ありがとう！"  , 0.05f , true);
                        SaveAndLoad.SaveData.EventProgress.Cat += 1;
                    }
                }
            }
            PlayerData.GameMode = "Rest";
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(0);
            }
            Timer.RestStartTime = DateTime.Now;
            PlayerData.Money = Timer.StartMoney + (Timer.HourPlusMin / Timer.MoneySpan) * 100;
            EventUI.SetActive(false);
            Resting = true;
        }
    }
}
