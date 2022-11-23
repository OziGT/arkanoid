using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus1 : Bonus
{
    public GameObject[] childs;

	public override void StartBonus()
    {
        foreach(var child in childs)
        {
            child.SetActive(true);
        }
    }

    public void EndBonus()
    {
        foreach (var child in childs)
        {
            child.SetActive(false);
        }
    }
}
