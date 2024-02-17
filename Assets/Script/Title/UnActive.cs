using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnActive : MonoBehaviour
{
    GameObject TextOuter;
    // Start is called before the first frame update
    void Start()
    {
        TextOuter = GameObject.Find("TextOuter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        TextOuter.SetActive(false);
    }
}
