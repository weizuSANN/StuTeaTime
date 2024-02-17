using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        LoadEnd = false;
        PlayerData = this.gameObject.GetComponent<PlayerData>();
        FilePath = Application.persistentDataPath + "/" + "SaveData.json";
        if(!File.Exists(FilePath))
        {
            SaveData.First = PlayerData.First;
            SaveData.Coins = PlayerData.Money;
            Save(SaveData);
            LoadEnd = true;
        }
        else
        {
            SaveData Data = Load();
            PlayerData.First = Data.First;
            PlayerData.Money = Data.Coins;
            LoadEnd = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveOK == false)
        {
            SaveData.First = PlayerData.First;
            SaveData.Coins = PlayerData.Money;
            Save(SaveData);
            SaveOK = true;
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
}
[System.Serializable]
public class SaveData
{
    public bool First;
    public int Coins;
    public int TotalSec;
    public int TotalMin;
    public int TotalHou;
    public List<string> NextFree;
}