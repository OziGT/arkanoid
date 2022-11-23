using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnabled : MonoBehaviour
{

    private void OnEnable()
    {
        AdManager.instance.InterAd();
    }
}
