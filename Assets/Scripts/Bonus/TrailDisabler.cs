using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDisabler : MonoBehaviour
{
    public TrailRenderer trail;
    float y;

	void Start ()
    {
        y = transform.position.y;
	}
	
	void Update ()
    {
		if(Mathf.Abs(y-transform.position.y)<0.5)
        {
            trail.time = 0;
        }
        else
        {
            trail.time = 3;
        }
	}
}
