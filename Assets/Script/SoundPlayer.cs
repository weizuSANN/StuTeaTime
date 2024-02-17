using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public int SoundID = -1;
    [SerializeField]private int LastSoundID = -1;
    public List<Sound> SoundList = new List<Sound>();
    public AudioSource Audio;
    public double Delay = 0;
    public bool IsIntroEnd = false;
    public bool IsMusicStart = false;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(LastSoundID != SoundID)
        {
            Audio.time = 0;
            Audio.clip = SoundList[SoundID].Audio;
            Delay = 0;
            IsIntroEnd = false;
            IsMusicStart = false;
        }
        
        
        if(IsMusicStart == false)
        {
            if(IsIntroEnd == true)
            {
                Audio.time = SoundList[SoundID].LoopStartTime;
            }
            Delay = 0;
            Audio.Play();
            IsMusicStart = true;
        }
        Delay += Time.deltaTime;
        if(IsIntroEnd == false)
        {
            if(Delay <= SoundList[SoundID].LoopStartTime)
            {
                //
            }
            else
            {
                IsIntroEnd = true;
                Delay = 0;
            }
        }
        if(IsIntroEnd == true)
        {
            if(Delay >= SoundList[SoundID].EndTime - SoundList[SoundID].LoopStartTime)
            {
                IsMusicStart = false;
            }
        }
        
        LastSoundID = SoundID;
    }
}
[System.Serializable]
public class Sound
{
    public AudioClip Audio;
    public float LoopStartTime;
    public float EndTime;
    [TextArea(1,10)]
    public string Memo;
}
