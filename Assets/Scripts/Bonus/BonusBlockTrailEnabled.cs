using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlockTrailEnabled : MonoBehaviour
{

    TrailRenderer particleSystem;
    private void Start()
    {
        particleSystem = GetComponent<TrailRenderer>();
        OnEnable();
    }

    private void OnEnable()
    {
        particleSystem.enabled = OptionsManager.instance.trails;
    }
}
