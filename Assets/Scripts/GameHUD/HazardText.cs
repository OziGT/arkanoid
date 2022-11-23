using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardText : MonoBehaviour
{
    public IsReachedBottom hazardLine;
    public UnityEngine.UI.Text text;
    int dist;
    public float min, max;
    public UnityEngine.UI.Image image;
    Color tmp=Color.white;
    public float a;

	void Update ()
    {
        if (hazardLine.distance < 0.4f)
        {
            dist = (int)Remap(hazardLine.distance, min, max, 0, 10);
            text.text = dist.ToString();
            tmp.a = Mathf.Clamp(Mathf.Abs(((float)dist/10)-1) + 0.2f, 0, 1);
            image.color = tmp;
            text.color= tmp;
        }
        else
        {
            image.color = Vector4.zero;
            text.color = Vector4.zero;
        }
        a = tmp.a;
	}

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
