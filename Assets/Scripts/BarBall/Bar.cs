using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Animation animation;
    public BoxCollider2D collider;
    public SpriteRenderer sprite;

    
	
    public void Shoot()
    {
        if (!animation.isPlaying)
        {
            animation.Play();
            collider.enabled = true;
            sprite.enabled = true;
            SoundManager.instance.Shot(0);
        }
    }


    void Update()
    {
        if (!animation.isPlaying)
        {
            collider.enabled = false;
            sprite.enabled = false;
        }
    }
}
