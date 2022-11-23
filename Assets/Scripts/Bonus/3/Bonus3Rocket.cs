using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus3Rocket : MonoBehaviour
{
    public Transform bar;
    public Rigidbody2D rb;
    bool launch = false, sound = false;
    public float thrust,explosionRadius;
    public ParticleSystem explosion;

	void Update ()
    {
		if(launch)
        {
            rb.AddForce(transform.up * thrust * Time.deltaTime);
        }
        else
        {
            transform.rotation = bar.rotation;
            transform.localEulerAngles += new Vector3(0, 0, -90);
        }
	}

    public void Launch()
    {
        if(enabled)
        {
            //SoundManager.instance.Rocket();
            launch = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==10)
        {
            Explode();
        }
        if(collision.gameObject.tag=="TopEdge")
        {
            Explode();
        }

    }

    void Explode()
    {
        LayerMask layerMask = LayerMask.NameToLayer("Block");
        Collider2D[] blocks = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        explosion.Play();
        explosion.transform.position = transform.position;
        int blocksExploded = 0;
        foreach(Collider2D block in blocks)
        {
            if(block.gameObject.layer==10)
            {
                if (block.transform.gameObject.activeSelf)
                {
                    blocksExploded++;
                    block.transform.gameObject.SetActive(false);
                    ParticleManager.instance.SpawnBlockExplode(block.transform.position);
                }
                //block.gameObject.SetActive(false);
            }
            
        }
        GameManager.instance.blocksLeft -= blocksExploded;
        transform.position = new Vector3(0, -50, 0);
        launch = false;
        transform.position = bar.position + new Vector3(0, 0, -1);
        gameObject.SetActive(false);
        GameManager.instance.CheckIfAnyBlocksAreLeft();
    }
}
