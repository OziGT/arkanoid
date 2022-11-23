using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveMatter : MonoBehaviour
{
    public Text text;
    public Transform ball;
    public Transform topEdge;
    public Animation animation;
    bool on = true;
    public float offset;
    private void OnEnable()
    {
        text.text = "x " + GameManager.instance.lives;
    }

    public void UpdateLiveMatter()
    {
        text.text = "x " + GameManager.instance.lives;
    }

    private void Update()
    {
        if(on)
        {
            if(ball.transform.position.y>topEdge.transform.position.y-offset)
            {
                animation.Play("LiveMatterOff");
                on = false;
            }
        }
        else
        {
            if (ball.transform.position.y <= topEdge.transform.position.y - offset)
            {
                animation.Play("LiveMatterOn");
                on = true;
            }
        }
    }
}
