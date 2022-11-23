using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float distance;
    float force;
    public Transform root;
    public ParticleSystem ps;
    public SpriteRenderer sprite;
    public float[] distanceRanges;
    public float[] powerTable;
    public int power =0;
    public Ball ball;
    public BallColor ballcollor;
    public float forceFromEdges;


    private void Update()
    {
        distance = Vector3.Distance(root.position, transform.position);
    }

    Color ChangeColor(int power)
    {
        switch (power)
        {
            case 1:
                return Color.white;
                break;
            case 2:
                return  Color.cyan;
                break;
            case 3:
                return  Color.blue;
                break;
            case 4:
                return  Color.green;
                break;
            case 5:
                return  Color.yellow;
                break;
            case 6:
                return Color.red;
                break;
        };
        return Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            power = 0;
            rb.velocity =Vector2.zero;
            distance = Vector3.Distance(root.position, transform.position);

            for (int i=0;i<distanceRanges.Length;i++)
            {
                if(distanceRanges[i]>=distance)
                {
                    power = i;
                    force = powerTable[i];
                }
                
            }
            power++;
            rb.AddForce(collision.transform.right*force*Time.deltaTime,ForceMode2D.Impulse);
            ps.Play();
            Debug.DrawRay(root.position, collision.transform.right*8, Color.red,2,false);
            collision.GetComponent<BoxCollider2D>().enabled = false;
            sprite.enabled = false;
            ball.power = power;
            var psMain = ps.main;
            psMain.startColor = ChangeColor(power);
            ballcollor.ChangeColor(power);
            SoundManager.instance.Shot(power);
        }
        
        if(collision.gameObject.layer==15)
        {
            GameManager.instance.LostLive();
        }
    }

    int one(float x)
    {
        if (x < 0)
            return 1;
        else
            return -1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer==17)
        {
            rb.AddForce(Vector2.down * 50 * Time.deltaTime);
        }
        if (collision.gameObject.layer == 14)
        {
            rb.AddForce((Vector2.down + (Vector2.right * one(transform.localPosition.x))) * Time.deltaTime * forceFromEdges);
            Debug.DrawRay(ball.transform.position, (Vector2.down + (Vector2.right * one(transform.localPosition.x))) * 3, Color.green, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.Bounce();
        /*
        if (collision.gameObject.layer == 10)
        {
            if (--ball.power <= 1)
            {
                ball.power = 1;
            }
            else
            {
                rb.velocity *= 0.75f;
            }
            ballcollor.ChangeColor(ball.power);
        }
        */
    }

}
