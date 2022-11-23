using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public static BonusManager instance;
    public Bonus[] bonuses;
    public GameObject BonusBlockPrefab;
    public Transform BlockRoot;
    public List<GameObject> bonusBlocks=new List<GameObject>();

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }

    public void Spawn(int bonus, Vector3 pos)
    {
        if(bonusBlocks.Count==0)
        {
            SpawnOne(bonus, pos);
        }
        else
        {
            bool found = false;
            foreach(var block in bonusBlocks)
            {
                if(block.activeSelf==false)
                {
                    block.SetActive(true);
                    found = true;
                    block.transform.position = pos;
                    block.GetComponent<BonusBlock>().bonus = bonus;
                    break;
                }
            }
            if(!found)
            {
                SpawnOne(bonus, pos);
            }
        }
    }

    void SpawnOne(int bonus, Vector3 pos)
    {
        GameObject block = Instantiate(BonusBlockPrefab) as GameObject;
        block.transform.parent = BlockRoot.transform;
        block.transform.position = pos;
        block.GetComponent<BonusBlock>().bonus = bonus;
        block.GetComponent<BonusBlock>().Run();
        bonusBlocks.Add(block);
    }

    public void StartBonus(int bonus)
    {
        bonuses[bonus-1].StartBonus();
    }
    
}
