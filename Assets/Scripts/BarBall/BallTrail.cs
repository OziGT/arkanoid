using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrail : MonoBehaviour
{

    public Ball ball;
    public TrailRenderer trail;
    int power = 0;

	void Update ()
    {
		if(power!=ball.power)
        {
            power = ball.power;
            switch (power)
            {
                case 1:
                    trail.startColor = Color.white;
                    trail.endColor = new Vector4(1,1,1,0);
                    break;
                case 2:
                    trail.startColor = Color.cyan;
                    trail.endColor = new Vector4(0,1,1,0);
                    break;
                case 3:
                    trail.startColor = Color.blue;
                    trail.endColor = new Vector4(0,0,1,0);

                    break;
                case 4:
                    trail.startColor = Color.green;
                    trail.endColor = new Vector4(0,1,0,0);
                    break;
                case 5:
                    trail.startColor = Color.yellow;
                    trail.endColor = new Vector4(1,0.92f,0.016f,0);
                    break;
                case 6:
                    trail.startColor = Color.red;
                    trail.endColor = new Vector4(1,0,0,0);
                    break;
            };
        }
	}
}
