using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsReachedBottom : MonoBehaviour
{
    public Animation anim;
    public bool on = false;
    public Transform blockRoot;
    public SpriteRenderer sprite;
    public Collider2D collider;
    public float distance=10;

    private void OnEnable()
    {
        sprite.color = new Vector4(1, 1, 1, 0);
    }

    private void Update()
    {
        if(collider.IsTouchingLayers())
        {
            if (!on)
            {
                if (!anim.isPlaying)
                {
                    anim.Play("HazardOn");
                    on = true;
                }
            }
        }
        else
        {
            if (on)
            {
                if (!anim.isPlaying)
                {
                    anim.Play("HazardOff");
                    distance = 10;
                    on = false;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (distance > collision.transform.position.y)
        {
            distance = collision.transform.position.y;
        }
        if (collision.transform.position.y<-1.02f)
        {
            blockRoot.localPosition = new Vector3(-2.8f, 3, 0);
            GameManager.instance.BlockHitBottom();
        }
    }
    
}
