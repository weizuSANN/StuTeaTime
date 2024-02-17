using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleFade : MonoBehaviour
{
    public bool FadeEventState;
    bool LastFadeEventState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LastFadeEventState != FadeEventState)
        {
            StartCoroutine("FadeEvent");
        }
        LastFadeEventState = FadeEventState;
    }
    IEnumerator FadeEvent()
    {
        Canvas FadeCanvas = GameObject.Find("FadeCanvas").GetComponent<Canvas>();
        Image Fade = this.gameObject.GetComponent<Image>();
        FadeCanvas.sortingOrder = 5;
        for(int i = 0; i <= 255; i++)
        {
            Fade.color = new Color(0 , 0 , 0 , (float)i / 255.0f);
            yield return new WaitForSeconds(0.001f);
        }
        SceneManager.LoadScene("SampleScene");
        FadeCanvas.sortingOrder = 10000;
        for(int i = 255; i >= 0; i--)
        {
            Fade.color = new Color(0 , 0 , 0 , (float)i / 255.0f);
            yield return new WaitForSeconds(0.001f);
        }
        Destroy(GameObject.Find("FadeUI"));
    }
}
