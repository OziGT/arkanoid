using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus1DeleteOnHit : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
