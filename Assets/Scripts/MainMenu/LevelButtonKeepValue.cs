using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonKeepValue : MonoBehaviour
{
    public int level; 

    public void ChangeLevel()
    {
        GameManager.instance.level = level;
        GameManager.instance.LevelStart();
    }
}
