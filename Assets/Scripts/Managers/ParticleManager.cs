using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;
    public Transform ParticleRoot;
    public GameObject blockExplodePrefab;

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

    public void SpawnBlockExplode(Vector3 pos)
    {
        if (OptionsManager.instance.particles)
        {
            bool found = false;
            foreach (Transform particle in ParticleRoot.GetComponentInChildren<Transform>())
            {
                if (!particle.GetComponent<ParticleSystem>().isPlaying)
                {
                    particle.position = pos;
                    particle.GetComponent<ParticleSystem>().Play();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                SpawnOne(pos);
            }
        }
    }

    void SpawnOne(Vector3 pos)
    {
        GameObject particle = Instantiate(blockExplodePrefab) as GameObject;
        particle.transform.parent = ParticleRoot.transform;
        particle.transform.position = pos;
    }
}
