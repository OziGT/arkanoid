using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLiveLevel : MonoBehaviour
{
    public UnityEngine.UI.InputField live, level;
    public Save save;

    public void Live()
    {
        int.TryParse(live.text,out GameManager.instance.lives);
        save.SaveGameValues();
    }

    public void Level()
    {
        int.TryParse(level.text, out GameManager.instance.level);
        save.SaveGameValues();
    }
}
