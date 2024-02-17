using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    bool DontDestroyExist;
    // Start is called before the first frame update
    void Start()
    {
        if(DontDestroyExist == false)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyExist = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
