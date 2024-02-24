using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class TextScript : MonoBehaviour
{
    //場合による
    Image CharacterImage;
    //テキスト表示必須項目
    public bool NonClick;
    public bool IsTextEnd;
    public bool IsMaxText;
    public char[] MsgChar;
    public int i = 0;
    public int NowText;
    public float TextSpeed = 0.05f;
    public string TextMessage;
    public float delay;
    public string CharacterName;
    public bool StartMessage;
    AudioSource Audio;
    GameObject TextUI;
    GameObject TextCanvas;
    GameObject Content;
    GameObject Name;
    public AudioClip[] SE;//上から、表示音、決定音
    Text Text;
    Text Chara;
    public string[] MsgArray;

    string LastGameMode;
    float NonClickTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //場合による
        CharacterImage = GameObject.Find("CharacterImage").GetComponent<Image>();
        //テキスト表示必須項目
        TextUI = GameObject.Find("TextUI");
        TextCanvas = GameObject.Find("TextCanvas");
        Content = GameObject.Find("Text");
        Name = GameObject.Find("Name");
        Text = Content.GetComponent<Text>();
        Chara = Name.GetComponent<Text>();
        Audio = this.gameObject.GetComponent<AudioSource>();
        TextCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //テキスト表示必須項目
        if(StartMessage == true)
        {
            Chara.text = CharacterName;
            MsgArray = Regex.Split(TextMessage , @"\s*" + "<>" + @"\s*" , RegexOptions.IgnorePatternWhitespace);
            if(IsTextEnd == true || TextMessage == null)
            {
                return;
            }
            if(!IsMaxText)
            {
                if(delay >= TextSpeed)
                {
                    Text.text += MsgArray[NowText][i];
                    //Audio.PlayOneShot(SE[0]);
                    i++;
                    delay = 0.0f;
                    if(i >= MsgArray[NowText].Length)
                    {
                        IsMaxText = true;
                    }
                }
                delay += Time.deltaTime;
                if(Input.GetMouseButtonDown(0))
                {
                    Text.text += MsgArray[NowText].Substring(i);
                    IsMaxText = true;
                }
            }
            if(IsMaxText)
            {
                delay += Time.deltaTime;
                if(NonClick == false)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        Audio.PlayOneShot(SE[1]);
                        i = 0;
                        NowText++;
                        Text.text = "";
                        delay = 0.0f;
                        IsMaxText = false;
                        if(NowText >= MsgArray.Length)
                        {
                            IsTextEnd = true;
                        }
                    }
                }
                else
                {
                    NonClickTime += Time.deltaTime;
                    if(NonClickTime >= 3.0f)
                    {
                        Audio.PlayOneShot(SE[1]);
                        i = 0;
                        NowText++;
                        Text.text = "";
                        delay = 0.0f;
                        NonClickTime = 0.0f;
                        IsMaxText = false;
                        if(NowText >= MsgArray.Length)
                        {
                            IsTextEnd = true;
                        }
                    }
                }
                
            }
            if(IsTextEnd == true)
            {
                NonClickTime = 0.0f;
                TextCanvas.SetActive(false);
                //必須
                StartMessage = false;
            }
        }
    }
    public void Message(string TextName , string Msg , float Speed = 0.05f , bool EnableClick = false , Sprite Picture = null)
    {
        //テキスト表示必須項目
        TextSpeed = Speed;
        i = 0;
        NowText = 0;
        Text.text = "";
        IsMaxText = false;
        IsTextEnd = false;
        TextCanvas.SetActive(true);
        CharacterName = TextName;
        TextMessage = Msg;
        StartMessage = true;
        NonClick = EnableClick;
        CharacterImage.sprite = Picture;
    }
    /*string[] WordWrap(string Msg)
    {
        float MojiCount = 0;
        char[] CharArray = Msg.ToCharArray();
        List<string> TextList = new List<string>();
        string TextExample = "";
        for(int j = 0; j <= CharArray.Length; i++)
        {
            if(MojiCount >= 12.0f)
            {
                TextList.Add(TextExample + "<>");
            }
            if(0x21 <= CharArray[j] &&CharArray[j] <= 0x7E)
            {
                MojiCount += 0.5f;
            }
            else
            {
                MojiCount += 1.0f;
            }
            TextExample += CharArray[j];
        }
        return TextList.ToArray();
    }*/
}
