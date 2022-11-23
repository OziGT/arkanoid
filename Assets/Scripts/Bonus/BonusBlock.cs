using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public int bonus;
    public Collider2D collider;
    public BonusBlockGraphic graphic;

    public void Run()
    {
        graphic.Show();
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (collider == Physics2D.OverlapPoint(touchPos))
            {
                BonusManager.instance.StartBonus(bonus);
                gameObject.SetActive(false);
            }
        }
    }
}
