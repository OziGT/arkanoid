using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBonus : MonoBehaviour
{
    public int bonus;
	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(2))
        {

            BonusManager.instance.StartBonus(bonus);
            gameObject.SetActive(false);
        }
    }
         
}
