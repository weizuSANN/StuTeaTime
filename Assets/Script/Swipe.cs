using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    //本プログラムはどのコンポーネントにもアタッチされていないため、変更不要です。一応消しても動きます。
    float ViewerOver = 25.0f;
    Vector2 StartPos;
    Vector2 EndPos;
    Vector2 FirstPos;

    float flickX;
    float flickY;

    RectTransform RectTransform;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform = this.gameObject.GetComponent<RectTransform>();
        FirstPos = RectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            StartPos = new Vector2(Input.mousePosition.x , 0);
        }
        if(Input.GetMouseButton(0) == true)
        {
            EndPos = new Vector2(Input.mousePosition.x , 0);
            RectTransform.anchoredPosition += (EndPos - StartPos);
            StartPos = EndPos;
        }
        if(RectTransform.anchoredPosition.x >= ViewerOver + FirstPos.x)
        {
            RectTransform.anchoredPosition = new Vector2(ViewerOver + FirstPos.x , FirstPos.y);
        }
        else if(RectTransform.anchoredPosition.x <= -ViewerOver + FirstPos.x)
        {
            RectTransform.anchoredPosition = new Vector2(-ViewerOver + FirstPos.x , FirstPos.y);
        }
        

    }
}
