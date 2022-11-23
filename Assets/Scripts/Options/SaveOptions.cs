using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOptions : MonoBehaviour
{
    int Level;
    OptionsData optionsData=new OptionsData();
    string path;
    bool encrypt = false;
    string logText = "";

    void Awake()
    {
        //the filename where saved data will be stored
        path = Application.persistentDataPath + "/" + "Options";
        //path = @"C:\Users\stalker\AppData\LocalLow\Ozi\plik";
    }

    public void SaveGameValues()
    {
        optionsData.particles = OptionsManager.instance.particles;
        optionsData.trails = OptionsManager.instance.trails;
        optionsData.sounds = OptionsManager.instance.sounds;
        SaveManager.Instance.Save(optionsData, path, DataWasSaved, encrypt);

    }
    

    public void LoadGameValues()
    {
        SaveManager.Instance.Load<OptionsData>(path, DataWasLoaded, encrypt);
    }

    private void DataWasLoaded(OptionsData data, SaveResult result, string message)
    {
        if (result == SaveResult.EmptyData || result == SaveResult.Error)
        {
            SaveGameValues();
        }
        if (result == SaveResult.Success)
        {
              OptionsManager.instance.particles= data.particles;
              OptionsManager.instance.trails= data.trails;
              OptionsManager.instance.sounds= data.sounds;
        }
    }

    private void DataWasSaved(SaveResult result, string message)
    {
        
    }
}

[System.Serializable]
public class OptionsData
{
    public bool sounds, trails, particles;
}