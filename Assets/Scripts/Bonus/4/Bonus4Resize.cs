using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus4Resize : MonoBehaviour
{
    public Transform ball;
    bool active=false;
    float time;
    public TextMesh text;

    private void Update()
    {
        if(active)
        {
            time += Time.deltaTime;
            if(time>10)
            {
                ball.localScale = new Vector3(2, 2, 1);
                active = false;
                transform.position = ball.position;
                text.text = (Mathf.Floor(10 - time)).ToString();
            }
        }
        else
        {
            transform.position = Vector3.left * 64;
        }
    }

    public void StartBonus()
    {
        ball.localScale = new Vector3(4, 4, 1);
        time = 0;
        active = true;
    }
}
