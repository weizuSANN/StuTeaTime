using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    PlayerData PlayerData;
    public SaveData SaveData;
    public bool LoadEnd;
    public bool SaveOK;
    string FilePath;
    // Start is called before the first frame update
    void Start()
    {
        FilePath = Application.persistentDataPath + "/" + "SaveData.json";
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            LoadEnd = false;
            PlayerData = this.gameObject.GetComponent<PlayerData>();
            if(!File.Exists(FilePath))
            {
                SaveData.First = PlayerData.First;
                SaveData.Coins = PlayerData.Money;
                Save(SaveData);
                LoadEnd = true;
            }
            else
            {
                SaveData = Load();
                PlayerData.First = SaveData.First;
                PlayerData.Money = SaveData.Coins;
                PlayerData.OrderMenu = SaveData.OrderMenu;
                Debug.Log("LoadCompleted");
                LoadEnd = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            if(SaveOK == false)
            {
                SaveData.First = PlayerData.First;
                SaveData.Coins = PlayerData.Money;
                SaveData.OrderMenu = PlayerData.OrderMenu;
                Save(SaveData);
                Debug.Log("SaveCompleted");
                SaveOK = true;
            }
        }
        
        
    }
    public void Save(SaveData Data)
    {
        string json = JsonUtility.ToJson(Data);
        StreamWriter writer = new StreamWriter(FilePath , false);
        writer.WriteLine(json);
        writer.Close();
    }
    public SaveData Load()
    {
        StreamReader reader = new StreamReader(FilePath);
        string json = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<SaveData>(json);
    }
    public bool ExistSaveData()
    {
        return File.Exists(FilePath);
    }
}
[System.Serializable]
public class SaveData
{
    public bool First;
    public int Coins;
    public int TotalSec;
    public int TotalMin;
    public int TotalHou;
    public int TotalCount;
    public List<string> OrderMenu = new List<string>();
    public EventBool EventProgress;
}
[System.Serializable]
public class EventBool
{
    public int Cat;
    public int Master;
    public int Bird;
}