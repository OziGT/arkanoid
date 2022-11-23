using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMove : MonoBehaviour
{

	
	void Update ()
    {
        transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
        if(transform.localPosition.y<-6)
        {
            gameObject.SetActive(false);
        }
	}
}
