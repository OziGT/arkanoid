using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] audio;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Button()
    {
        audio[2].Play();
    }

    public void Shot(int power)
    {
        audio[4].pitch = 1 + (power / 10);
        audio[4].Play();
    }

    public void Bounce()
    {
        audio[1].Play();
    }

    public void BlockBreak()
    {
        audio[0].Play();
    }

    public void Rocket()
    {
        audio[3].Play();
    }
}
