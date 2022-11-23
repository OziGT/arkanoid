using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus4CollisionExit : MonoBehaviour
{
    bool touch = true;
    public Transform ball;
    public Bonus4Resize bonus4;

    private void Update()
    {
        transform.position = ball.position;
        if(!touch)
        {
            bonus4.StartBonus();
            gameObject.SetActive(false);
        }
        touch = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer==12|| collision.gameObject.layer == 10 || collision.gameObject.layer == 8)
        {
            touch = true;
        }
    }
}
