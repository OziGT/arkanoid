using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject[] buttonTick;

	void Start ()
    {
        OnEnable();
	}

    private void OnEnable()
    {
        OptionsManager.instance.Load();
        UpdateTick();

    }

    public void Sounds()
    {
        OptionsManager.instance.sounds = !OptionsManager.instance.sounds;
        UpdateTick();
    }

    public void Particles()
    {
        OptionsManager.instance.particles = !OptionsManager.instance.particles;
        UpdateTick();
    }

    public void Trails()
    {
        OptionsManager.instance.trails = !OptionsManager.instance.trails;
        UpdateTick();
    }

    void UpdateTick()
    {
        buttonTick[0].SetActive(OptionsManager.instance.sounds);
        buttonTick[1].SetActive(OptionsManager.instance.trails);
        buttonTick[2].SetActive(OptionsManager.instance.particles);
    }
}
