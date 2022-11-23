using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Renderer[] materials;
    public Transform camera;
    float prevCam,tmp;
    public float[] ratio;

    private void Start()
    {
        prevCam = camera.transform.position.y;
    }
    private void Update()
    {
        transform.position = new Vector3(0, camera.transform.position.y, 20);
        for (int i=0;i<3;i++)
        {
            materials[i].material.mainTextureOffset = new Vector2(0, (camera.transform.position.y) * ratio[i]);
        }
        prevCam = camera.transform.position.y;
    }
}
