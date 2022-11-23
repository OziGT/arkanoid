using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    int Level;
    SaveData saveData=new SaveData();
    string path;
    bool encrypt = true;
    string logText = "";

    void Awake()
    {
        //the filename where saved data will be stored
        path = Application.persistentDataPath + "/" + "velocity.sav";
        //path = @"C:\Users\stalker\AppData\LocalLow\Ozi\plik";
    }

    public void SaveGameValues()
    {
        saveData.level = GameManager.instance.level;
        saveData.lives = GameManager.instance.lives;
        if(GameManager.instance.finished)
        {
            saveData.finished = "x5o78e31";
        }
        else
        {
            saveData.finished = "x5o7ae31";
        }
        saveData.day = System.DateTime.Now.Day;
        SaveManager.Instance.Save(saveData, path, DataWasSaved, encrypt);
    }

    void SaveNew()
    {
        GameManager.instance.level = 0;
        GameManager.instance.lives = 30;
        GameManager.instance.lastDay = -1;
        saveData.finished = "x5o7ae31";
        saveData.level = 0;
        saveData.lives = 30;
        saveData.day =- 1;
        SaveManager.Instance.Save(saveData, path, DataWasSaved, encrypt);
    }

    public void LoadGameValues()
    {
        SaveManager.Instance.Load<SaveData>(path, DataWasLoaded, encrypt);
    }

    private void DataWasLoaded(SaveData data, SaveResult result, string message)
    {
        if (result == SaveResult.EmptyData || result == SaveResult.Error)
        {
            
            SaveNew();
            Debug.Log("Load error "+result);
        }
        if (result == SaveResult.Success)
        {
            //saveData = data;
            GameManager.instance.level = data.level;
            GameManager.instance.lives = data.lives;
            GameManager.instance.lastDay = data.day;
            if(data.finished== "x5o78e31")
            {
                GameManager.instance.finished = true;
            }
            Debug.Log("Load succes");
        }
    }

    private void DataWasSaved(SaveResult result, string message)
    {
        
    }
}

[System.Serializable]
public class SaveData
{
    public int level,lives,day;
    public string finished;
}