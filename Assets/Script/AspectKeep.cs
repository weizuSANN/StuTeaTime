using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectKeep : MonoBehaviour
{
    public Vector2 TargetAspect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float realAspect = (float)Screen.width / (float)Screen.height;
        float floatTargetAspect = TargetAspect.x / TargetAspect.y;
        
        float magRate = floatTargetAspect / realAspect;

        Rect viewPortRect = new Rect(0 , 0 , 1 , 1);
        viewPortRect.width = magRate;
        this.gameObject.GetComponent<Camera>().rect = viewPortRect;
    }
}
