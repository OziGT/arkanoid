using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float offset;
    public Transform topEdge;
    public Transform ball;
    public Vector3 bottomEdge;
    public Transform Camera;

    void Update()
    {
         if (ball.transform.position.y < bottomEdge.y + offset || topEdge.localPosition.y<5.8)
        {
            Camera.position = new Vector3(0, Mathf.Lerp(Camera.position.y, bottomEdge.y + offset, Time.deltaTime * 4), -10);
            return;
        }
        else if(ball.transform.position.y > topEdge.position.y - offset)
        {
            Camera.position = new Vector3(0, Mathf.Lerp(Camera.position.y, topEdge.position.y - offset, Time.deltaTime * 4), -10);
            return;
        }
        
        else
        {
            Camera.position = new Vector3(0, Mathf.Lerp(Camera.position.y, ball.position.y, Time.deltaTime * 4), -10);
        }
    }

    public void CameraReset()
    {
        Camera.position = new Vector3(0, 0, -10);
    }
}
