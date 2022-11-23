using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarStartAim : MonoBehaviour
{
    public Transform Bar, Ball, BallStartPoint;
    public Slider slider;
	
	void Update ()
    {
        Ball.position = BallStartPoint.position;
        Bar.localEulerAngles = new Vector3(0, 0, -slider.value);
	}
}
