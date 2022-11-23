using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour
{
    float fallingSpeed=0;
    Vector3 fallingVector;
    public Transform topEdge;

    private void Start()
    {
        transform.localPosition = new Vector3(-2.8f, 3, 0);
        fallingSpeed = GameManager.instance.fallingSpeed;
        fallingVector = new Vector3(0, fallingSpeed * Time.deltaTime, 0);
    }
    void Update ()
    {
       
            transform.localPosition -= fallingVector * Time.deltaTime;
            topEdge.localPosition -= fallingVector * Time.deltaTime;

    }

    private void OnEnable()
    {
        fallingSpeed = GameManager.instance.fallingSpeed;
        fallingVector = new Vector3(0, fallingSpeed * Time.deltaTime, 0);
    }
}
