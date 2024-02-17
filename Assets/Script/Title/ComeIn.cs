using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComeIn : MonoBehaviour
{
    TitleFade TitleFade;
    // Start is called before the first frame update
    void Start()
    {
        TitleFade = GameObject.Find("FadeObject").GetComponent<TitleFade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        TitleFade.FadeEventState = true;
    }
}
