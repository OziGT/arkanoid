using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance;
    public bool sounds, trails, particles;
    public AudioSource[] Sounds;
    public TrailRenderer[] Trails;
    public ParticleSystem[] Particles;

    SaveOptions saveOptions;
    void Start()
    {
        saveOptions = GetComponent<SaveOptions>();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        saveOptions.LoadGameValues();
        Change();
    }

    void Change()
    {
        foreach (var i in Sounds)
        {
            i.enabled = sounds;
        }
        foreach (var i in Trails)
        {
            i.enabled = trails;
        }
        foreach (var i in Particles)
        {
            i.enableEmission = particles;
        }
    }

    public void Save()
    {
        saveOptions.SaveGameValues();
        Change();
    }

    public void Load()
    {
        saveOptions.LoadGameValues();
        Change();
    }
}
