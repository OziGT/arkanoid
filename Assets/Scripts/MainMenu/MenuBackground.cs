using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    public Renderer[] materials;
    public Vector2 speed;
	
	// Update is called once per frame
	void Update ()
    {
		
        if(materials[0].material.mainTextureOffset.y>=1000)
        {
            foreach (var material in materials)
            {
                material.material.mainTextureOffset = Vector2.zero;
            }
        }
        else
        {
            foreach (var material in materials)
            {
                material.material.mainTextureOffset += speed*Time.deltaTime;
            }
        }
	}
}
