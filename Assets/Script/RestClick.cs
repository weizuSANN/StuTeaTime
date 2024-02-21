using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestClick : MonoBehaviour
{
    public AudioClip SE;
    AudioSource AudioSource;
    PlayerData PlayerData;
    Timer Timer;
    public int Price;
    public bool Resting;
    GameObject EventUI;
    CharacterCome CharacterCome;
    TextScript TextScript;
    GameObject SystemManager;
    SaveAndLoad SaveAndLoad;
    SoundPlayer SoundPlayer;
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
        AudioSource = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        SoundPlayer = GameObject.Find("SoundPlayer").GetComponent<SoundPlayer>();
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
                        EventUI.SetActive(false);
                        TextScript.Message("マスター" , "ご来店ありがとうございます。<>久しぶりお客様なので少しお話をしたいなと。<>私は古緋と言います<>昔はこの店にも常連のお客様がいたのですが、<>最近ぱたりと来なくなってしまいまして、<>もともと趣味の店ですし、経営は問題ないのですが、<>やはり寂しくて<>長話が過ぎました。すみません。どうぞごゆっくり" , 0.08f , true , CharacterCome.Sprites[1]);
                        SaveAndLoad.SaveData.EventProgress.Master += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Master == 1 && SaveAndLoad.SaveData.TotalCount > 5  && SaveAndLoad.SaveData.EventProgress.Bird == 2)
                    {
                        EventUI.SetActive(false);
                        TextScript.Message("常連客" , "こんにちは。こちら席を使ってもよろしいかな？<>うん？ああ、マスターから私のことを聞いたのか。<>私は影山という。学生のときから、ここに通っていて<>マスターにはよく話を聞いてもらったものだ。<>最近は仕事が忙しくて、<>なかなか来られなくなってしまったけどね<>今日来たのは、昨日ここの前を通りかかったとき、<>緑の小鳥がここの窓に入っていくのが見えたからだ<>私が昔ここで見た鳥にそっくりでね。<>またあの鳥に会いたくなったんだ。<>え、あの鳥はまだここに花を置きに来てるのかい？<>はは、そうか…ではまた会えるかもしれないな<>話を聞いてくれてありがとう。私はもう行くよ" , 0.05f , true , CharacterCome.Sprites[2]);
                        SaveAndLoad.SaveData.EventProgress.Master += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Master == 2 && SaveAndLoad.SaveData.TotalCount > 8)
                    {
                        EventUI.SetActive(false);
                        TextScript.Message("マスター" , "ああお客様。本日もご来店ありがとうございます。<>いきなりで申し訳ありませんが、以前話した方が<>またいらっしゃってくれるようになられたそうです。<>やはり、お客様がたくさんいる<>というのはいいものですね<>おお、もうお話になられたのですか。<>彼も話し相手が欲しいでしょうし、<>よかったらまた話してみてください。<>未だ来てくださる方は少ないので、<>今後ともよろしくお願いいたします" , 0.05f , true , CharacterCome.Sprites[1]);
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
                        EventUI.SetActive(false);
                        TextScript.Message("青い鳥" , "ああ、こんにちは。休憩中ですか？<>私はミズノといいます。<>…ここで何をしているのかって？<>実は、私の子供が、そろそろ巣立ちの時期なのです。<>ですが、全く飛ぼうとしてくれなくて、<>なのでこうして飛ぶお手本を見せているんです<>この花は、昔この喫茶店にも世話になったお礼です<>それでは、私はこれで" , 0.05f , true , CharacterCome.Sprites[9]);
                        SaveAndLoad.SaveData.EventProgress.Bird += 1;
                        //会話始まったら勉強時間リセットされるバグあり.
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Bird == 1 && SaveAndLoad.SaveData.TotalCount > 4)
                    {
                        EventUI.SetActive(false);
                        TextScript.Message("翠の鳥" , "初めまして。僕はミドリっていうんだ。<>え、飛べるようになったのかって。<>もしかして、パパに聞いた？<>飛ぶのって何か怖そうで、<>ずっとできなかったんだけど、<>お客さんが来なくてマスターが<>寂しそうにしてたから、頑張ってみたんだ。<>僕が来れば、少しはマスターも気が紛れるかなって" , 0.05f , true , CharacterCome.Sprites[11]);
                        SaveAndLoad.SaveData.EventProgress.Bird += 1;
                    }
                    if(SaveAndLoad.SaveData.EventProgress.Bird == 2 && SaveAndLoad.SaveData.TotalCount > 6)
                    {
                        EventUI.SetActive(false);
                        TextScript.Message("青い鳥" , "こんにちは。お話いいですか？<>ついに息子が飛んでくれました。<>なんでもマスターのためだとか<>優しい子に育って、私は嬉しいです。<>そういえば、息子があなたとお話をさせてもらった<>と言っていました。<>私らの事情にお付き合いありがとうございます。<>今後は二人でお邪魔させていただきます" , 0.05f , true , CharacterCome.Sprites[9]);
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
                        EventUI.SetActive(false);
                        TextScript.Message("黒猫" , "よお。お前休憩中か？<>なら俺の話聞いてくれよ。<>最近全然客来ねーし暇なんだよ<>俺はクロ。ずっとこの店で暮らしてる。<>昔はちょっとは客がきてたんだけど、今はこの有様<>そんでな、昔ここにきてた客が、<>めっちゃ可愛い猫連れてきてたんだ<>俺その子と友達になりたかったんだけど、<>飼い主がなんか来なくなっちゃって、<>それ以来会えてないんだよ<>ふわふわの白猫で、この辺りの家のやつらしいから、<>もしそれっぽい猫居たら教えてくれよ。<>そんじゃーねー" , 0.05f , true , CharacterCome.Sprites[5]);
                        SaveAndLoad.SaveData.EventProgress.Cat += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Cat == 1 && SaveAndLoad.SaveData.TotalCount > 5)
                    {
                        EventUI.SetActive(false);
                        TextScript.Message("白猫" , "どうも、あたしはアイ。<>あたしの飼い主以外の客なんて珍しいわね。<>ここの黒猫？知ってるけど、どうかしたの？<>あたしと友達になりたいって？…まあ別に構わないわ<>けど、それなら自分から声をかけるべきじゃない？<>あたしの飼い主も、またここに通うことに<>したらしいし、会う機会なら何回かあるでしょ。<>それじゃあたしは帰るわね"  , 0.05f , true , CharacterCome.Sprites[7]);
                        SaveAndLoad.SaveData.EventProgress.Cat += 1;
                    }
                    else if(SaveAndLoad.SaveData.EventProgress.Cat == 2 && SaveAndLoad.SaveData.TotalCount > 8)
                    {
                        EventUI.SetActive(false);
                        TextScript.Message("黒猫" , "なあなあ、聞いてくれ。<>前話した子と友達になれたんだ！<>突然また飼い主が来るようになったみたいだからさ、<>勇気を出して話しかけてみたんだよ。<>そしたら大成功したんだ！<>ん？お前が俺のこと話しといてくれたのか？<>マジか、ほんとにありがとう。<>これからはあの子と一緒にお邪魔するよ<>じゃ、またねー"  , 0.05f , true , CharacterCome.Sprites[5]);
                        SaveAndLoad.SaveData.EventProgress.Cat += 1;
                    }
                }
            }
            PlayerData.GameMode = "Rest";
            if(PlayerData.MenuList.Count != 0)
            {
                PlayerData.MenuList.RemoveAt(0);
                Timer.RestStartTime = DateTime.Now;
                PlayerData.Money = Timer.StartMoney + (Timer.HourPlusMin / Timer.MoneySpan) * 100;
                Resting = true;
            }
        }
        AudioSource.PlayOneShot(SE);
        SoundPlayer.SoundID = 3;
    }
}
