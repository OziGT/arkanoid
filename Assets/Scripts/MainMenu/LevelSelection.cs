using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject buttonPrefab;
    public RectTransform content;
    public int offset;

    private void Start()
    {
        ShowButtons();
    }
    public void ShowButtons()
    {
        int count = 0;
        int y = -140;
        while (count < GameManager.instance.maxLevel)
        {
            for (int x = -400; x < 401; x += offset)
            {
                if(count>=GameManager.instance.maxLevel)
                {
                    break;
                }
                GameObject button = Instantiate(buttonPrefab) as GameObject;
                button.transform.parent = content;
                //button.transform.localPosition = new Vector3(x, y, 0);
                button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
                button.GetComponent<Transform>().localScale = Vector3.one;
                button.transform.GetComponent<LevelButtonKeepValue>().level=count;
                count++;
            }
            y -= offset;
        }
    }
}
