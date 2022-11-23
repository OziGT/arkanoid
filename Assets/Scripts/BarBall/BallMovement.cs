using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Rigidbody2D rb;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonUp(1))
        {
            rb.AddForce(Vector2.down*200);
        }


	}
}
