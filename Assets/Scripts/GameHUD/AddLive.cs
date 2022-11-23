using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLive : MonoBehaviour
{
    public void Add()
    {
        GameManager.instance.lives++;
        GameManager.instance.liveMatter[0].UpdateLiveMatter();
        GameManager.instance.liveMatter[1].UpdateLiveMatter();
    }
}
