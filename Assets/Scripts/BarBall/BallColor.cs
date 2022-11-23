using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{
    public SpriteRenderer sprite;

    public void ChangeColor(int power)
    {
        switch (power)
        {
            case 1:
                sprite.color = Color.white;
                break;
            case 2:
                sprite.color = Color.cyan;
                break;
            case 3:
                sprite.color = Color.blue;
                break;
            case 4:
                sprite.color = Color.green;
                break;
            case 5:
                sprite.color = Color.yellow;
                break;
            case 6:
                sprite.color = Color.red;
                break;
        };
    }
}
