using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonText : MonoBehaviour
{
    public Text text;
    public LevelButtonKeepValue buttonKeepValue;
    int x;
    private void Start()
    {
        x = buttonKeepValue.level + 1;
        text.text = x.ToString();
        if(x>=100)
        {
            text.fontSize = 46;
        }
    }
}
