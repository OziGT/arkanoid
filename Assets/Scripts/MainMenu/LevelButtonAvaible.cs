using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonAvaible : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Image sprite;
    public LevelButtonKeepValue level;

    private void Start()
    {
        OnEnable();
    }
    private void OnEnable()
    {
        if(level.level<GameManager.instance.level)
        {
            sprite.color = Color.green;
            button.enabled = false;
        }
        else if(level.level>=GameManager.instance.level&&level.level<=GameManager.instance.level+(int)(GameManager.instance.level/10))
        {
            sprite.color = Color.yellow;
            button.enabled = true;
        }
        else
        {
            sprite.color = Color.red;
            button.enabled = false;
        }
    }
}
