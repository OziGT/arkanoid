using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarRootSprite : MonoBehaviour
{
    public Bounce bounce;
    public SpriteRenderer[] sp;
    public float offset;

	void Update ()
    {
        for (int i = 0; i < bounce.distanceRanges.Length; i++)
        {
            sp[i].enabled = false;
            if (bounce.distanceRanges[i] - offset >= bounce.distance)
            {
                sp[i].enabled = true;
            }

        }
    }
}
