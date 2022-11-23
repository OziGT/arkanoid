using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus2BounceAndDelete : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Ball ball;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        ball.power = 6;
        sprite.color = Color.red;
        ball.gameObject.GetComponent<Rigidbody2D>().velocity *= 2;
    }
}
