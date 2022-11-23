using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFollowBall : MonoBehaviour
{
    public Transform ball;

	
	void Update ()
    {
        if (ball.localPosition.y > -3.6f)
        {
            Vector3 dir = ball.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
