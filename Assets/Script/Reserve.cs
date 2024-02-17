using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reserve : MonoBehaviour
{
    Timer Timer;
    public List<AnimalMove> AnimalMove = new List<AnimalMove>();
    public int ComeToAnimalSpan = 40;
    public int Last40Min;
    RectTransform Rect;
    Vector3 StartPosition = new Vector3(0 , 0 , 0);
    // Start is called before the first frame update
    void Start()
    {
        Rect = this.gameObject.GetComponent<RectTransform>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.HourPlusMin / ComeToAnimalSpan != Last40Min)
        {
            SummonAnimals(AnimalMove[Random.Range(0 , AnimalMove.Count)]);
        }
        Last40Min = Timer.HourPlusMin / ComeToAnimalSpan;
    }
    public void SummonAnimals(AnimalMove Animals)
    {
        this.gameObject.GetComponent<Image>().sprite = Animals.AnimalImage;
        for(int i = 0; i <= Animals.MovePosition.Count -1; i++)
        {
            //StartPosition = Rect.anchoredPosition;
            Rect.rotation = Quaternion.Euler(Animals.MoveRotation[i]);
            Rect.localScale = Animals.MoveScale[i];
            Rect.localPosition = Vector2.MoveTowards(Rect.localPosition , Animals.MovePosition[i] , Animals.MoveSpeed[i] * Time.deltaTime);
        }
    }
}
[System.Serializable]
public class AnimalMove
{
    public Sprite AnimalImage;
    //パラパラ漫画のように座標を動かす。リストのサイズは統一しないといけない
    public List<Vector3> MovePosition = new List<Vector3>();
    public List<Vector3> MoveRotation = new List<Vector3>();
    public List<Vector3> MoveScale = new List<Vector3>();
    public List<float> MoveSpeed = new List<float>();
}
