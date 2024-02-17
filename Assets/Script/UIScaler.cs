using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour
{
    float ScreenWidth , ScreenHeight;
    RectTransform IllustRect;
    RectTransform Rect;
    // Start is called before the first frame update
    void Start()
    {
        IllustRect = GameObject.Find("Illust").GetComponent<RectTransform>();
        Rect = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        Debug.Log(ScreenWidth);
        Debug.Log(ScreenHeight);
        if(ScreenWidth > IllustRect.sizeDelta.x * IllustRect.localScale.x)
        {
            Rect.localScale = new Vector2(ScreenWidth / (IllustRect.sizeDelta.x * IllustRect.localScale.x) , ScreenWidth / (IllustRect.sizeDelta.x * IllustRect.localScale.x));
        }
        else
        {
            Rect.localScale = new Vector2(ScreenHeight / (IllustRect.sizeDelta.y * IllustRect.localScale.y) , ScreenHeight / (IllustRect.sizeDelta.y * IllustRect.localScale.y));
        }
        
    }
}
